using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CRUDbiblioteca.clienteDependencias
{
    namespace CRUDbiblioteca
    {
        public class funcoesLivro
        {
            private string conexaoString = ConfigurationManager.ConnectionStrings["SQLSERVER_LOCAL"].ConnectionString;

            public int CalcularNovaDisponibilidade(int idLivro, int novoTotalDigitado)
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    string sql = "SELECT COUNT(0) FROM emprestimo WHERE idLivro = @id AND status = 'Ativo'";
                    SqlCommand cmd = new SqlCommand(sql, conexao);
                    cmd.Parameters.AddWithValue("@id", idLivro);

                    conexao.Open();

                    int qtdEmprestadaReal = Convert.ToInt32(cmd.ExecuteScalar());

                    return novoTotalDigitado - qtdEmprestadaReal;
                }
            }

            public string ExcluirLivro(int id, int qtdParaRemover)
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    conexao.Open();
                    SqlTransaction transacao = conexao.BeginTransaction();

                    try
                    {
                        string sqlBusca = "SELECT qtdTotal, qtdDisp FROM livro WHERE idLivro = @id";
                        SqlCommand cmdBusca = new SqlCommand(sqlBusca, conexao, transacao);
                        cmdBusca.Parameters.AddWithValue("@id", id);

                        int totalAtual = 0;
                        int dispAtual = 0;

                        using (SqlDataReader dr = cmdBusca.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                totalAtual = Convert.ToInt32(dr["qtdTotal"]);
                                dispAtual = Convert.ToInt32(dr["qtdDisp"]);
                            }
                        }

                        if (qtdParaRemover > dispAtual)
                        {
                            transacao.Rollback();
                            return $"Não é possivel excluir livro com emprestimos em ativo!";
                        }

                        if (qtdParaRemover >= totalAtual)
                        {
                            string sqlDelEmp = "DELETE FROM emprestimo WHERE idLivro = @id";
                            SqlCommand cmdDelEmp = new SqlCommand(sqlDelEmp, conexao, transacao);
                            cmdDelEmp.Parameters.AddWithValue("@id", id);
                            cmdDelEmp.ExecuteNonQuery();

                            string sqlDelLivro = "DELETE FROM livro WHERE idLivro = @id";
                            SqlCommand cmdDelLivro = new SqlCommand(sqlDelLivro, conexao, transacao);
                            cmdDelLivro.Parameters.AddWithValue("@id", id);
                            cmdDelLivro.ExecuteNonQuery();
                        }
                        else
                        {
                            string sqlUpd = "UPDATE livro SET qtdTotal -= @qtd, qtdDisp -= @qtd WHERE idLivro = @id";
                            SqlCommand cmdUpd = new SqlCommand(sqlUpd, conexao, transacao);
                            cmdUpd.Parameters.AddWithValue("@qtd", qtdParaRemover);
                            cmdUpd.Parameters.AddWithValue("@id", id);
                            cmdUpd.ExecuteNonQuery();
                        }

                        transacao.Commit();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        transacao.Rollback();
                        return "Erro ao processar: " + ex.Message;
                    }
                }
            }

            public string CadastrarLivro(string titulo, string autor, int anoPublica, int qtdTotal, int qtdDisp)
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    string sql = "INSERT INTO livro (titulo, autor, anoPublica, qtdTotal,qtdDisp) VALUES (@titulo,@autor,@anoPublica,@qtdTotal,@qtdDisp)";
                    SqlCommand cmd = new SqlCommand(sql, conexao);

                    cmd.Parameters.AddWithValue("@titulo", titulo);
                    cmd.Parameters.AddWithValue("@autor", autor);
                    cmd.Parameters.AddWithValue("@anoPublica", anoPublica);
                    cmd.Parameters.AddWithValue("@qtdTotal", qtdTotal);
                    cmd.Parameters.AddWithValue("@qtdDisp", qtdDisp);

                    try
                    {
                        conexao.Open();
                        cmd.ExecuteNonQuery();
                        return null;
                    }
                    catch (Exception ex) 
                    { 
                        return "Erro ao cadastrar novo livro: " + ex.Message; 
                    }
                }
            }

            public string EditarLivro(int id, string titulo, string autor, int anoPublica, int qtdTotal, int qtdDisp)
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    string sql = "UPDATE livro SET titulo = @titulo, autor = @autor, anoPublica = @anoPublica, qtdTotal = @qtdTotal, qtdDisp = @qtdDisp WHERE idLivro=@id";
                    SqlCommand cmd = new SqlCommand(sql, conexao);

                    cmd.Parameters.AddWithValue("@titulo", titulo);
                    cmd.Parameters.AddWithValue("@autor", autor);
                    cmd.Parameters.AddWithValue("@anoPublica", anoPublica);
                    cmd.Parameters.AddWithValue("@qtdTotal", qtdTotal);
                    cmd.Parameters.AddWithValue("@qtdDisp", qtdDisp);
                    cmd.Parameters.AddWithValue("@id", id);

                    try
                    {
                        conexao.Open();
                        cmd.ExecuteNonQuery();
                        return null;
                    }
                    catch (Exception ex) { return "Erro: " + ex.Message; }
                }
            }


            public DataTable ListarLivro()
            {
                DataTable tabela = new DataTable();
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    string sql = "SELECT idLivro,titulo, autor, anoPublica, qtdTotal, qtdDisp FROM livro";
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

            public int ObterIdLivro(string titulo, string autor, int anoPublica)
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    string sql = "SELECT idLivro FROM livro WHERE titulo = @t AND autor = @a AND anoPublica = @ano";
                    SqlCommand cmd = new SqlCommand(sql, conexao);
                    cmd.Parameters.AddWithValue("@t", titulo);
                    cmd.Parameters.AddWithValue("@a", autor);
                    cmd.Parameters.AddWithValue("@ano", anoPublica);

                    conexao.Open();
                    object resultado = cmd.ExecuteScalar();

                    return (resultado != null) ? Convert.ToInt32(resultado) : 0;
                }
            }

            public DataTable BuscarLivroPorId(int id)
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    string sql = "SELECT qtdTotal, qtdDisp FROM livro WHERE idLivro = @id";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conexao);
                    da.SelectCommand.Parameters.AddWithValue("@id", id);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }
    }
}