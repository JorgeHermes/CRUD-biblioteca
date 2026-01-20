using CRUDbiblioteca.clienteDependencias.CRUDbiblioteca;
using CRUDbiblioteca.forms;
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
        funcoesCliente dao = new funcoesCliente();

        public FrmClientes()
        {
            InitializeComponent();
            AtualizarGrade();
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            AtualizarGrade();
            LimparCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (CamposInvalidos()) return;


            int idSelecionado = int.Parse(labId.Text);

            if (DadosUnicos(dao, idSelecionado)) return;

            dao.Editar(idSelecionado, txtNome.Text.Trim(), txtEmail.Text.Trim(), maskTelefone.Text.Trim(), maskCpf.Text.Trim(), cmbTipo.Text.Trim());

            MessageBox.Show("Dados atualizados com sucesso!");
            AtualizarGrade();
            LimparCampos();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null || string.IsNullOrEmpty(labId.Text) || labId.Text == "0")
            {
                MessageBox.Show("Selecione um cliente na grade primeiro.");
                return;
            }

            int idSelecionado = int.Parse(labId.Text);

            if (dao.TemEmprestimoAtivo("idCliente", idSelecionado))
            {
                MessageBox.Show("Não é possível excluir este cliente pois ele possui empréstimos ativos.",
                                "Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacao = MessageBox.Show("Deseja realmente excluir este cliente? Isso apagará também o histórico de empréstimos já concluídos.",
                                                      "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                string erro = dao.Excluir(idSelecionado);

                if (erro == null)
                {
                    MessageBox.Show("Cliente removido com sucesso!");
                    AtualizarGrade();
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show(erro);
                }
            }
        }


        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (CamposInvalidos()) return;

            if(DadosUnicos(dao)) return;


            string erro = dao.Cadastrar(txtNome.Text.Trim(), txtEmail.Text.Trim(), maskTelefone.Text.Trim(), maskCpf.Text.Trim(), cmbTipo.Text.Trim());

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
            labId.Text = "0";
        }

        private void AtualizarGrade()
        {
            dgvClientes.DataSource = dao.Listar();                                     
            dgvClientes.Columns["idCliente"].Visible = false;
        }

        private bool CamposInvalidos()
        {
            if (!string.IsNullOrEmpty(maskTelefone.Text) && maskTelefone.Text.Length < 11)
            {
                MessageBox.Show(@"Telefone incompleto! Por favor verifique e tente novamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O Nome é obrigatório.");
                txtNome.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Insira um E-mail válido.");
                txtEmail.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(maskCpf.Text))
            {
                MessageBox.Show("É necessário o CPF!");
                maskCpf.Focus();
                return true;
            }

            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o Tipo de Cliente.");
                cmbTipo.Focus();
                return true;
            }

            int cpf = maskCpf.Text.Length;
            if (cpf < 11)
            {
                MessageBox.Show(@"CPF incompleto! Por favor verifique e tente novamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false;
        }

        private bool DadosUnicos(funcoesCliente dao, int? idSelecionado = null)
        {
            if (dao.ExisteNoBanco("cpf", maskCpf.Text, idSelecionado)) 
            { 
                MessageBox.Show("Este CPF já pertence a OUTRO cliente!");
                maskCpf.Focus();
                return true; 
            }

            if (dao.ExisteNoBanco("email", txtEmail.Text, idSelecionado)) 
            { 
                MessageBox.Show("Este Email já pertence a OUTRO cliente!");
                txtEmail.Focus();
                return true; 
            }

            return false;
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            menu.Show(this);
            this.Close();
        }
    }
}