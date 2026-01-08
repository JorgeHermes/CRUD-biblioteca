using CRUDbiblioteca.clienteDependencias.CRUDbiblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
            if (!ValidarCamposObrigatorios()) return;

            int idSelecionado = int.Parse(labId.Text);

            funcoesCliente dao = new funcoesCliente();

            if (dao.ExisteNoBancoEditar("cpf", maskCpf.Text, idSelecionado))
            {
                MessageBox.Show("Este CPF já pertence a OUTRO cliente!");
                return;
            }

            if (dao.ExisteNoBancoEditar("email", txtEmail.Text, idSelecionado))
            {
                MessageBox.Show("Este Email já pertence a OUTRO cliente!");
                return;
            }

            dao.Editar(idSelecionado, txtNome.Text, txtEmail.Text, maskTelefone.Text, maskCpf.Text, cmbTipo.Text);

            MessageBox.Show("Dados atualizados com sucesso!");
            AtualizarGrade();
            LimparCampos();

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
            funcoesCliente dao = new funcoesCliente();

            if (!ValidarCamposObrigatorios()) return;

            if (dao.ExisteNoBanco("cpf", maskCpf.Text)) { MessageBox.Show("CPF já existe!"); return; }
            if (dao.ExisteNoBanco("email", txtEmail.Text)) { MessageBox.Show("Email já existe!"); return; }

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

            dgvClientes.Columns["idCliente"].Visible = false;
        }

        private bool ValidarCamposObrigatorios()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O Nome é obrigatório.");
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Insira um E-mail válido.");
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(maskCpf.Text))
            {
                MessageBox.Show("É necessário o CPF!");
                maskCpf.Focus();
                return false;
            }

            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o Tipo de Cliente.");
                cmbTipo.Focus();
                return false;
            }

            return true; // Se não caiu em nenhum IF, está tudo OK!
        }

        private void dgvClientes_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow linha = dgvClientes.Rows[e.RowIndex];

                labId.Text = linha.Cells["idCliente"].Value.ToString();
                txtNome.Text = linha.Cells["nome"].Value.ToString();
                txtEmail.Text = linha.Cells["email"].Value.ToString();
                maskTelefone.Text = linha.Cells["telefone"].Value.ToString();
                maskCpf.Text = linha.Cells["cpf"].Value.ToString();
                cmbTipo.Text = linha.Cells["tipoCliente"].Value.ToString();

            }
        }


    }
}