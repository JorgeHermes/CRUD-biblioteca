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
        public class ClienteDAO
        {
            // Certifique-se de que a string de conexão está correta para o seu PC
            private string conexaoString = ConfigurationManager.ConnectionStrings["SQLSERVER_LOCAL"].ConnectionString;

            public string Cadastrar(modelCliente objetoCliente) 
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    string sql = "INSERT INTO cliente (nome, email, telefone) VALUES (@nome, @email, @telefone)";
                    SqlCommand cmd = new SqlCommand(sql, conexao);

                    // Vinculando os dados do MODEL (Cliente) aos parâmetros do SQL
                    cmd.Parameters.AddWithValue("@nome", objetoCliente.Nome);

                    // Trata o email nulo
                    if (string.IsNullOrEmpty(objetoCliente.Email))
                        cmd.Parameters.AddWithValue("@email", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@email", objetoCliente.Email);

                    cmd.Parameters.AddWithValue("@telefone", objetoCliente.Telefone ?? (object)DBNull.Value);

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
                    // Certifique-se que os nomes das colunas batem com o seu banco
                    string sql = "SELECT idCliente, nome, cpf, email, telefone, tipoCliente FROM cliente";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conexao);

                    try
                    {
                        conexao.Open();
                        adapter.Fill(tabela); // Preenche a tabela com os dados do banco
                    }
                    catch (Exception ex)
                    {
                        // Se der erro aqui, ele avisará o motivo (ex: nome de tabela errado)
                        throw new Exception("Erro ao buscar dados: " + ex.Message);
                    }
                }
                return tabela;
            }

        }
    }
}

