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

            public string EditarLivro(int id, string titulo, string autor, int anoPublica, int qtdTotal)
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    string sql = "UPDATE livro SET titulo=@titulo, autor=@autor, anoPublica=@anoPublica, qtdTotal=@qtdTotal WHERE idLivro=@id";
                    SqlCommand cmd = new SqlCommand(sql, conexao);

                    cmd.Parameters.AddWithValue("@titulo", titulo);
                    cmd.Parameters.AddWithValue("@autor", autor);
                    cmd.Parameters.AddWithValue("@anoPublica", anoPublica);
                    cmd.Parameters.AddWithValue("@qtdTotal", qtdTotal);
                    cmd.Parameters.AddWithValue("@id", id);

                    try
                    {
                        conexao.Open();
                        cmd.ExecuteNonQuery();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        return "Erro ao editar: " + ex.Message;
                    }
                }
            }

            public string ExcluirLivro(int id, int qtdParaRemover)
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    try
                    {
                        conexao.Open();

                        string sqlBusca = "SELECT qtdTotal FROM livro WHERE idLivro = @id";
                        SqlCommand cmdBusca = new SqlCommand(sqlBusca, conexao);
                        cmdBusca.Parameters.AddWithValue("@id", id);

                        int qtdAtual = Convert.ToInt32(cmdBusca.ExecuteScalar());

                        string sqlFinal;
                        if (qtdParaRemover >= qtdAtual)
                        {
                            sqlFinal = "DELETE FROM livro WHERE idLivro = @id";
                        }
                        else
                        {
                            sqlFinal = "UPDATE livro SET qtdTotal = qtdTotal - @qtdRemover WHERE idLivro = @id";
                        }

                        SqlCommand cmdFinal = new SqlCommand(sqlFinal, conexao);
                        cmdFinal.Parameters.AddWithValue("@id", id);
                        cmdFinal.Parameters.AddWithValue("@qtdRemover", qtdParaRemover);

                        cmdFinal.ExecuteNonQuery();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        return "Erro ao processar exclusão: " + ex.Message;
                    }
                }
            }

            public DataTable ListarLivro()
            {
                DataTable tabela = new DataTable();
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    string sql = "SELECT * FROM livro";
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

            public int ObterIdExisteNoBancoLivro(string titulo, string autor, int anoPublica)
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    // Usamos UPPER para evitar problemas com maiúsculas/minúsculas
                    string sql = "SELECT idLivro FROM livro WHERE UPPER(titulo) = UPPER(@titulo) AND UPPER(autor) = UPPER(@autor) AND UPPER(anoPublica) = UPPER(@anoPublica)";
                    SqlCommand cmd = new SqlCommand(sql, conexao);
                    cmd.Parameters.AddWithValue("@titulo", titulo.Trim());
                    cmd.Parameters.AddWithValue("@autor", autor.Trim());
                    cmd.Parameters.AddWithValue("@anoPublica", anoPublica);

                    try
                    {
                        conexao.Open();
                        object resultado = cmd.ExecuteScalar();
                        return (resultado != null) ? Convert.ToInt32(resultado) : 0;
                    }
                    catch { return 0; }
                }
            }

            public bool ExisteNoBancoEditarLivro(string coluna, string valor, int idAtual)
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    string sql = $"SELECT COUNT(*) FROM livro WHERE {coluna} = @valor AND idLivro <> @id";

                    SqlCommand cmd = new SqlCommand(sql, conexao);
                    cmd.Parameters.AddWithValue("@valor", valor);
                    cmd.Parameters.AddWithValue("@id", idAtual);

                    conexao.Open();
                    int contagem = (int)cmd.ExecuteScalar();
                    return contagem > 0;
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