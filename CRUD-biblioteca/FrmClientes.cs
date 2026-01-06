using CRUDbiblioteca.clienteDependencias.CRUDbiblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDbiblioteca
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
            // REMOVIDA: A linha que tentava configurar o TableAdapter inexistente
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            // REMOVIDO: O método Fill que causava erro de login 'sa'
            AtualizarGrade();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            AtualizarGrade();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Selecione um cliente na grade primeiro.");
                return;
            }

            DialogResult confirmacao = MessageBox.Show("Deseja realmente excluir este cliente?", "Confirmação", MessageBoxButtons.YesNo);

            if (confirmacao == DialogResult.Yes)
            {
                try
                {
                    // Agora usamos o valor da grade preenchida pelo seu DAO
                    int idSelecionado = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);

                    ClienteDAO dao = new ClienteDAO();
                    string erro = dao.Excluir(idSelecionado);

                    if (erro == null)
                    {
                        MessageBox.Show("Cliente removido com sucesso!");
                        AtualizarGrade();
                    }
                    else
                    {
                        MessageBox.Show(erro);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao converter ID: Selecione uma linha válida. " + ex.Message);
                }
            }
        }

        private void AtualizarGrade()
        {
            try
            {
                ClienteDAO dao = new ClienteDAO();
                // O DAO usa a sua string de conexão correta do App.config
                dgvClientes.DataSource = dao.Listar();

                if (dgvClientes.Columns.Contains("id"))
                {
                    dgvClientes.Columns["id"].HeaderText = "Código";
                    dgvClientes.Columns["id"].DisplayIndex = 0;
                }
            }
            catch (Exception ex)
            {
                // Mostra detalhes caso a conexão falhe
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        // Deixe os métodos de botão vazios por enquanto se não tiver lógica neles
        private void btnCadastrar_Click(object sender, EventArgs e) { }
        private void btnAtualizar_Click(object sender, EventArgs e) { }
    }
}
