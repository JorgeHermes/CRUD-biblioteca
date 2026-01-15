using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDbiblioteca.forms
{
    public partial class FrmHistorico : Form
    {
        private string conexaoString = ConfigurationManager.ConnectionStrings["SQLSERVER_LOCAL"].ConnectionString;
        public FrmHistorico()
        {
            InitializeComponent();
            GerarHistorico();

        }

        private void GerarHistorico() 
        {
            dgvHisto.DataSource = ListarEmprestimo();
        }

        private DataTable ListarEmprestimo()
        {
            DataTable tabela = new DataTable();
            using (SqlConnection conexao = new SqlConnection(conexaoString))
            {
                string sql = @"SELECT e.idLivro, l.titulo, e.idCliente, c.nome AS NomeCliente, dataEmprestimo, dataPrevistaDevolucao, dataDevolucao, status
                             FROM emprestimo e 
                             LEFT JOIN livro l ON e.idLivro = l.idLivro
                             LEFT JOIN cliente c ON e.idCliente = c.idCliente";
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmHistorico_Load(object sender, EventArgs e)
        {

        }
    }

     
}


