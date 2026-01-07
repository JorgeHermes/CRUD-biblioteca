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
                    string sql = "DELETE FROM cliente WHERE idCliente = @id";
                    SqlCommand cmd = new SqlCommand(sql, conexao);

                    cmd.Parameters.AddWithValue("@id", id);

                    try
                    {
                        conexao.Open();
                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                            return null;
                        else
                            return "Nenhum registro encontrado para excluir.";
                    }
                    catch (Exception ex)
                    {
                        return "Erro ao excluir: " + ex.Message;
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



        }
    }
}

