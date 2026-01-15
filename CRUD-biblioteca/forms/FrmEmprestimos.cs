using CRUDbiblioteca.clienteDependencias.CRUDbiblioteca;
using CRUDbiblioteca.modelos.emprestimoModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDbiblioteca.forms
{
    public partial class FrmEmprestimos : Form
    {
        public FrmEmprestimos()
        {
            InitializeComponent();
            AtualizarGrades();
            CarregarClientes();
        }

        private void AtualizarGrades()
        {
            try
            {
                funcoesEmprestimo dao = new funcoesEmprestimo();
                dgvEmprestimos.DataSource = dao.ListarEmprestimo();
                dgvLivrosEmprestimos.DataSource = dao.ListarLivroEmprestimo();
                dgvLivrosEmprestimos.Columns["idLivro"].Visible = false;
                dgvEmprestimos.Columns["idEmprestimo"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        private void dgvLivrosEmprestimos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dgvLivrosEmprestimos.Rows[e.RowIndex];

                labIdLivro.Text = linha.Cells["idLivro"].Value.ToString();
                txtAutor.Text = linha.Cells["autor"].Value.ToString();
                txtTitulo.Text = linha.Cells["titulo"].Value.ToString();
                txtAno.Text = linha.Cells["anoPublica"].Value.ToString();
            }
        }

        private void btnListarEmprestimo_Click(object sender, EventArgs e)
        {
            AtualizarGrades();
            CarregarClientes();
        }

        private void dgvEmprestimos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dgvEmprestimos.Rows[e.RowIndex];

                labIdEmprestimo.Text = linha.Cells["idEmprestimo"].Value.ToString();
                dataEmprestimo.Value = Convert.ToDateTime(linha.Cells["dataEmprestimo"].Value);
                dataPrevisaoDevolucao.Value = Convert.ToDateTime(linha.Cells["dataPrevistaDevolucao"].Value);
                labIdLivroEmp.Text = linha.Cells["idLivro"].Value.ToString();
                labIdClienteEmp.Text = linha.Cells["idCliente"].Value.ToString();
            }
        }

        private void CarregarClientes()
        {
            funcoesCliente dao = new funcoesCliente();

            DataTable dt = dao.Listar();

            cmbCliente.DataSource = dt;

            cmbCliente.DisplayMember = "nome";
            cmbCliente.ValueMember = "idCliente";
        }

        private void btnConfirmarEmprestimo_Click(object sender, EventArgs e)
        {
            int idLivroSelecionado = int.Parse(labIdLivro.Text);

            if (idLivroSelecionado == 0)
            {
                MessageBox.Show("Selecione um livro!");
                return;
            }
            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("Selecione um cliente!");
                return;
            }

            int idCliente = Convert.ToInt32(cmbCliente.SelectedValue);
            DateTime dataHoje = DateTime.Now;

            DateTime dataPrevisaoDevolucao = dataPrevista1.Value;

            funcoesEmprestimo dao = new funcoesEmprestimo();
            string erro = dao.CriarEmprestimo(idLivroSelecionado, idCliente, dataHoje, dataPrevisaoDevolucao);

            if (erro == null)
            {
                MessageBox.Show("Empréstimo registrado hoje: " + dataHoje.ToShortDateString());
                AtualizarGrades();
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Erro: " + erro);
            }
        }

        private void LimparCampos()
        {
            txtAno.Clear();
            txtAutor.Clear();
            txtTitulo.Clear();
            dataPrevista1.Value = DateTime.Now;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int idEmprestimo = int.Parse(labIdEmprestimo.Text);
            int idLivro = int.Parse(labIdLivroEmp.Text);
            int idCliente = int.Parse(labIdClienteEmp.Text);
            DateTime dataPrev = dataPrevisaoDevolucao.Value;


            funcoesEmprestimo dao = new funcoesEmprestimo();

            if (idEmprestimo == 0) 
            {
                MessageBox.Show("Selecione um Emprestimo!");
                return;
            }

            string resultado = dao.EditarEmprestimo(idEmprestimo, idLivro, idCliente, dataPrev);

            if (resultado == null)
            {
                MessageBox.Show("Emprestimo atualizado com sucesso!");
                AtualizarGrades();
            }

            else
            {
                MessageBox.Show("Erro ao editar: " + resultado);
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            int idEmprestimo = int.Parse(labIdEmprestimo.Text);
            DateTime dataDev = DateTime.Now;

            funcoesEmprestimo dao = new funcoesEmprestimo();

            if (idEmprestimo == 0)
            {
                MessageBox.Show("Selecione algum Emprestimo!");
                return;
            }

            string resultado = dao.DevolverLivro(idEmprestimo, dataDev);

            if (resultado == null)
            {
                MessageBox.Show("Livro devolvido com sucesso!");
                AtualizarGrades();
            }

            else
            {
                MessageBox.Show("Erro ao devolver: " + resultado);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            menu.Show(this);
            this.Close();
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            FrmHistorico telaHistorico = new FrmHistorico();
            telaHistorico.ShowDialog();
        }
    }
}