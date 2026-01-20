using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDbiblioteca.clienteDependencias
{
    namespace CRUDbiblioteca
    {
        public class funcoesCliente
        {
            private string conexaoString = ConfigurationManager.ConnectionStrings["SQLSERVER_LOCAL"].ConnectionString;

            public bool TemEmprestimoAtivo(string campoId, int id)
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    string sql = $"SELECT COUNT(0) FROM emprestimo WHERE {campoId} = @id AND status = 'Ativo'";

                    SqlCommand cmd = new SqlCommand(sql, conexao);
                    cmd.Parameters.AddWithValue("@id", id);

                    conexao.Open();
                    object resultado = cmd.ExecuteScalar();

                    return resultado != null && Convert.ToInt32(resultado) > 0;
                }
            }

            public string Cadastrar(string nome, string email, string telefone, string CPF,string TipoCliente)
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    string sql = "INSERT INTO cliente (nome, email, telefone, cpf,tipoCliente) VALUES (@nome,@email,@telefone,@cpf,@tipoCliente)";
                    SqlCommand cmd = new SqlCommand(sql, conexao);

                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@telefone", telefone);
                    cmd.Parameters.AddWithValue("@cpf", CPF);
                    cmd.Parameters.AddWithValue("@tipoCliente", TipoCliente);

                    try
                    {
                        conexao.Open();
                        cmd.ExecuteNonQuery();
                        return null;
                    }
                    catch (Exception ex) 
                    { 
                        return "Erro ao cadastrar novo cliente: " + ex.Message; 
                    }
                }
            }

            public string Editar(int id, string nome, string email, string telefone, string CPF, string TipoCliente)
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    string sql = "UPDATE cliente SET nome=@nome, email=@email, telefone=@telefone, cpf=@cpf,tipoCliente=@TipoCliente WHERE idCliente=@id";
                    SqlCommand cmd = new SqlCommand(sql, conexao);

                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@telefone", telefone);
                    cmd.Parameters.AddWithValue("@cpf", CPF);
                    cmd.Parameters.AddWithValue("@tipoCliente", TipoCliente);
                    cmd.Parameters.AddWithValue("@id",id);

                    try
                    {
                        conexao.Open();
                        cmd.ExecuteNonQuery();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        return "Erro ao editar cliente: " + ex.Message;
                    }
                }
            }

            public string Excluir(int id)
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    conexao.Open();
                    SqlTransaction transacao = conexao.BeginTransaction();

                    try
                    {
                        string sqlHist = "DELETE FROM emprestimo WHERE idCliente = @id";
                        SqlCommand cmdHist = new SqlCommand(sqlHist, conexao, transacao);
                        cmdHist.Parameters.AddWithValue("@id", id);
                        cmdHist.ExecuteNonQuery();

                        string sqlCli = "DELETE FROM cliente WHERE idCliente = @id";
                        SqlCommand cmdCli = new SqlCommand(sqlCli, conexao, transacao);
                        cmdCli.Parameters.AddWithValue("@id", id);
                        cmdCli.ExecuteNonQuery();

                        transacao.Commit();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        transacao.Rollback();
                        return "Erro ao excluir cliente: " + ex.Message;
                    }
                }
            }
            
            public DataTable Listar()
            {
                DataTable tabela = new DataTable();
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    string sql = "SELECT idCliente, nome, cpf, email, telefone, tipoCliente FROM cliente";
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

            public bool ExisteNoBanco(string coluna, string valor, int? idParaIgnorar = null)
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    string sql = $"SELECT COUNT(0) FROM cliente WHERE {coluna} = @valor";

                    if (idParaIgnorar.HasValue)
                        sql += " AND idCliente <> @id";

                    SqlCommand cmd = new SqlCommand(sql, conexao);
                    cmd.Parameters.AddWithValue("@valor", valor);

                    if (idParaIgnorar.HasValue)
                        cmd.Parameters.AddWithValue("@id", idParaIgnorar.Value);

                    conexao.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }

        }
    }
}