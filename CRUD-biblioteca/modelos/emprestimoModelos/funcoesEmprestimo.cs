using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDbiblioteca.modelos.emprestimoModelos
{
    internal class funcoesEmprestimo
    {
        private string conexaoString = ConfigurationManager.ConnectionStrings["SQLSERVER_LOCAL"].ConnectionString;

        public DataTable ListarLivros()
        {
            DataTable tabela = new DataTable();
            using (SqlConnection conexao = new SqlConnection(conexaoString))
            {
                string sql = "SELECT idLivro,titulo, autor, anoPublica, qtdDisp FROM livro WHERE qtdDisp > 0";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conexao);

                try
                {
                    conexao.Open();
                    adapter.Fill(tabela);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar dados: " + ex.Message);
                }
            }
            return tabela;
        }

        public DataTable ListarEmprestimos()
        {
            DataTable tabela = new DataTable();
            using (SqlConnection conexao = new SqlConnection(conexaoString))
            {
                string sql = @"SELECT e.idEmprestimo, e.idLivro, l.titulo AS TituloLivro, e.idCliente, c.nome AS NomeCliente, dataEmprestimo, dataPrevistaDevolucao, status
                             FROM emprestimo e 
                             LEFT JOIN livro l ON e.idLivro = l.idLivro
                             LEFT JOIN cliente c ON e.idCliente = c.idCliente 
                             WHERE e.status = 'Ativo'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conexao);

                try
                {
                    conexao.Open();
                    adapter.Fill(tabela);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar dados: " + ex.Message);
                }
            }
            return tabela;
        }

        public string CriarEmprestimo(int idLivro, int idCliente, DateTime dataEmp, DateTime dataPrevista)
        {
            using (SqlConnection conexao = new SqlConnection(conexaoString))
            {
                conexao.Open();
                SqlTransaction transacao = conexao.BeginTransaction();

                try
                {
                    string sqlEmp = @"INSERT INTO emprestimo (idLivro, idCliente, dataEmprestimo, dataPrevistaDevolucao, status) 
                              VALUES (@idL, @idC, @dataE, @dataP, 'Ativo')";

                    SqlCommand cmdEmp = new SqlCommand(sqlEmp, conexao, transacao);
                    cmdEmp.Parameters.AddWithValue("@idL", idLivro);
                    cmdEmp.Parameters.AddWithValue("@idC", idCliente);
                    cmdEmp.Parameters.AddWithValue("@dataE", dataEmp);
                    cmdEmp.Parameters.AddWithValue("@dataP", dataPrevista);
                    cmdEmp.ExecuteNonQuery();

                    string sqlLivro = "UPDATE livro SET qtdDisp -= 1 WHERE idLivro = @idL AND qtdDisp > 0";
                    SqlCommand cmdLivro = new SqlCommand(sqlLivro, conexao, transacao);
                    cmdLivro.Parameters.AddWithValue("@idL", idLivro);

                    int linhasAfetadas = cmdLivro.ExecuteNonQuery();

                    if (linhasAfetadas == 0)
                    {
                        transacao.Rollback();
                        return "Infelizmente o livro acabou de ficar indisponível.";
                    }

                    transacao.Commit();
                    return null;
                }
                catch (Exception ex)
                {
                    transacao.Rollback();
                    return "Erro ao processar empréstimo: " + ex.Message;
                }
            }
        }

        public string EditarEmprestimo(int idEmprestimo, int idLivro, int idCliente, DateTime dataPrev)
        {
            using (SqlConnection conexao = new SqlConnection(conexaoString))
            {
                string sql = "UPDATE emprestimo SET idLivro = @idLivro, idCliente = @idCliente, dataPrevistaDevolucao = @dataPrev WHERE idEmprestimo = @idEmp";

                SqlCommand cmd = new SqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@idEmp",idEmprestimo);
                cmd.Parameters.AddWithValue("@idLivro",idLivro);
                cmd.Parameters.AddWithValue("@dataPrev",dataPrev);
                cmd.Parameters.AddWithValue("@idCliente",idCliente);

                try
                {
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                    return null;
                }
                catch (Exception ex) 
                {
                    return ex.Message;
                }
            }
        }

        public string DevolverLivro(int idEmprestimo, int idLivro ,DateTime dataDev) 
        {
            using (SqlConnection conexao = new SqlConnection(conexaoString))
            {
                conexao.Open();
                SqlTransaction transacao = conexao.BeginTransaction();

                try
                {
                    // 1. Atualiza o empréstimo
                    // Adicionamos AND status = 'Ativo' para garantir que não devolveremos o mesmo livro duas vezes
                    string sqlEmp = @"UPDATE emprestimo 
                              SET dataDevolucao = GETDATE(), status = 'Concluído' 
                              WHERE idEmprestimo = @idEmp AND status = 'Ativo'";

                    SqlCommand cmdEmp = new SqlCommand(sqlEmp, conexao, transacao);
                    cmdEmp.Parameters.AddWithValue("@idEmp", idEmprestimo);

                    int linhasAfetadas = cmdEmp.ExecuteNonQuery();

                    // Se nenhuma linha foi afetada, o empréstimo já estava concluído ou não existe
                    if (linhasAfetadas == 0)
                    {
                        transacao.Rollback();
                        return "Este empréstimo já foi devolvido ou é inválido.";
                    }

                    // 2. Incrementa o estoque usando o operador +=
                    string sqlLivro = "UPDATE livro SET qtdDisp += 1 WHERE idLivro = @idLivro";
                    SqlCommand cmdLivro = new SqlCommand(sqlLivro, conexao, transacao);
                    cmdLivro.Parameters.AddWithValue("@idLivro", idLivro);
                    cmdLivro.ExecuteNonQuery();

                    transacao.Commit();
                    return null; // Sucesso
                }
                catch (Exception ex)
                {
                    transacao.Rollback();
                    return "Erro ao processar devolução: " + ex.Message;
                }
            }
        }
    }
}
