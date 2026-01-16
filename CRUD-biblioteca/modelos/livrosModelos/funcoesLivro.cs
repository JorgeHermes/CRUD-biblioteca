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

            public string EditarLivro(int id, string titulo, string autor, int anoPublica, int qtdTotal, int qtdDisp)
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    // Adicionamos qtdDisp=@qtdDisp no UPDATE
                    string sql = "UPDATE livro SET titulo=@titulo, autor=@autor, anoPublica=@anoPublica, qtdTotal=@qtdTotal, qtdDisp=@qtdDisp WHERE idLivro=@id";
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

                        string sql = "SELECT qtdTotal FROM livro WHERE idLivro = @id";
                        SqlCommand cmdBusca = new SqlCommand(sql, conexao);
                        cmdBusca.Parameters.AddWithValue("@id", id);

                        int qtdAtual = Convert.ToInt32(cmdBusca.ExecuteScalar());

                        string sqlDel;
                        if (qtdParaRemover >= qtdAtual)
                        {
                            sqlDel = "DELETE FROM livro WHERE idLivro = @id";
                        }
                        else
                        {
                            sqlDel = "UPDATE livro SET qtdTotal = qtdTotal - @qtdRemover WHERE idLivro = @id";
                        }

                        SqlCommand cmdFinal = new SqlCommand(sqlDel, conexao);
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
             
            public bool ExisteNoBanco(string tabela, string coluna, string valor, string nomeColunaId = "", int? idParaIgnorar = null)
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    string sql = $"SELECT COUNT(*) FROM {tabela} WHERE {coluna} = @valor";

                    if (idParaIgnorar.HasValue && !string.IsNullOrEmpty(nomeColunaId))
                    {
                        sql += $" AND {nomeColunaId} <> @id";
                    }

                    SqlCommand cmd = new SqlCommand(sql, conexao);
                    cmd.Parameters.AddWithValue("@valor", valor);

                    if (idParaIgnorar.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@id", idParaIgnorar.Value);
                    }

                    conexao.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
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