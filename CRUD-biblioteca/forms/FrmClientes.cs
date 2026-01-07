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
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            AtualizarGrade();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            AtualizarGrade();
            LimparCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e) 
        {
            if (dgvClientes.CurrentRow == null) 
            {
                MessageBox.Show("Selecione um cliente na grade primeiro");
                return;
            }

            int idSelecionado = 0;

            try 
            {
                idSelecionado = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao converter ID: Selecione uma linha válida. " + ex.Message);
            }

            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Você não pode deixar o nome ou e-mail vazios ao editar!");
                return;
            }
            funcoesCliente bd = new funcoesCliente();

            string erro = bd.Editar(idSelecionado, txtNome.Text, txtEmail.Text, maskTelefone.Text, maskCpf.Text, cmbTipo.Text);

            if (erro == null)
            {
                MessageBox.Show("Cliente atualizado com sucesso!");
                AtualizarGrade();
                LimparCampos();
            }
            else {
                MessageBox.Show(erro);
            }

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
                    int idSelecionado = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);

                    funcoesCliente dao = new funcoesCliente();
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


        private void btnCadastrar_Click(object sender, EventArgs e) 
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O Nome é obrigatório.");
                txtNome.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Insira um E-mail válido.");
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(maskCpf.Text))
            {
                MessageBox.Show("É necessário o CPF para seu cadastro!");
                return;
            }

            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o Tipo de Cliente.");
                return;
            }

            funcoesCliente dao = new funcoesCliente();
            string erro = dao.Cadastrar(txtNome.Text, txtEmail.Text, maskTelefone.Text, maskCpf.Text, cmbTipo.Text);

            if (erro == null)
            {
                MessageBox.Show("Cadastrado com sucesso!");
                AtualizarGrade();
                LimparCampos();
            }
            else
            {
                MessageBox.Show(erro);
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            maskCpf.Clear();
            maskTelefone.Clear();
            cmbTipo.SelectedIndex = -1;
            txtNome.Focus();
        }

        private void AtualizarGrade()
        {
            try
            {
                funcoesCliente dao = new funcoesCliente();
                dgvClientes.DataSource = dao.Listar();

                if (dgvClientes.Columns.Contains("id"))
                {
                    dgvClientes.Columns["id"].HeaderText = "Código";
                    dgvClientes.Columns["id"].DisplayIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dgvClientes.Rows[e.RowIndex];

                txtNome.Text = linha.Cells["nome"].Value.ToString();
                txtEmail.Text = linha.Cells["email"].Value.ToString();
                maskTelefone.Text = linha.Cells["telefone"].Value.ToString();
                maskCpf.Text = linha.Cells["cpf"].Value.ToString();
                cmbTipo.Text = linha.Cells["tipoCliente"].Value.ToString();
            }
        }
    }
    
}
