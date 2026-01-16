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

        public DataTable ListarLivroEmprestimo()
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

        public DataTable ListarEmprestimo()
        {
            DataTable tabela = new DataTable();
            using (SqlConnection conexao = new SqlConnection(conexaoString))
            {
                string sql = @"SELECT e.idEmprestimo, e.idLivro, l.titulo AS TituloLivro, e.idCliente, c.nome AS NomeCliente, dataEmprestimo, dataPrevistaDevolucao, dataDevolucao, status
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

        public string CriarEmprestimo(int idLivro, int idCliente, DateTime dataEmprestimo, DateTime dataPrevistaDevolucao)
        {
            using (SqlConnection conexao = new SqlConnection(conexaoString))
            {
                string sql = "INSERT INTO emprestimo (idLivro,IdCliente,dataEmprestimo,dataPrevistaDevolucao,dataDevolucao,status) VALUES (@idLivro, @idCliente, @data, @dataPrev,NULL ,'Ativo')";

                SqlCommand cmd = new SqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@idLivro", idLivro);
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cmd.Parameters.AddWithValue("@data", dataEmprestimo);
                cmd.Parameters.AddWithValue("@dataPrev", dataPrevistaDevolucao);

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

        public string DevolverLivro(int idEmprestimo, DateTime dataDev) 
        {
            using (SqlConnection conexao = new SqlConnection(conexaoString))
            {
                string sql = "UPDATE emprestimo SET dataDevolucao = @dataDev WHERE idEmprestimo = @idEmprestimo AND dataDevolucao IS NULL";

                SqlCommand cmd = new SqlCommand (sql, conexao);
                cmd.Parameters.AddWithValue("@idEmprestimo",idEmprestimo);
                cmd.Parameters.AddWithValue("@dataDev", dataDev);

                try
                {
                    conexao.Open();
                    int linhas = cmd.ExecuteNonQuery();

                    if (linhas == 0)
                        return "Este empréstimo já foi devolvido ou não existe.";

                    return null;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
