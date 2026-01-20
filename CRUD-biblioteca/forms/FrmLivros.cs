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
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDbiblioteca
{
    public partial class FrmLivros : Form
    {
        funcoesLivro dao = new funcoesLivro();

        public FrmLivros()
        {
            InitializeComponent();
            AtualizarGrade();
            dgvLivros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void LimparCampos()
        {
            txtAutor.Clear();
            txtTitulo.Clear();
            numQtdTotal.Value = 0;
            numQtdDisp.Value = 0;
            labIdLivro.Text = "0";
        }

        private void AtualizarGrade()
        {
            dgvLivros.DataSource = dao.ListarLivro();
            dgvLivros.Columns["idLivro"].Visible = false;
        }

        private bool ValidarCamposObrigatorios()
        {
            if (string.IsNullOrWhiteSpace(txtAutor.Text))
            {
                MessageBox.Show("O autor é obrigatório.");
                txtAutor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("O título é necessário para organizarmos o estoque!");
                txtTitulo.Focus();
                return false;
            }

            return true;
        }

        private void btnListarLivro_Click(object sender, EventArgs e)
        {
            AtualizarGrade();
            LimparCampos();
        }

        private void btnEditarLivro_Click(object sender, EventArgs e)
        {
            int idAtual = int.Parse(labIdLivro.Text);
            string novoTitulo = txtTitulo.Text.Trim();
            string novoAutor = txtAutor.Text.Trim();
            int novoAnoPublicacao = (int)numAno.Value;
            int novaQtdTotal = (int)numQtdTotal.Value;

            if (idAtual <= 0)
            {
                MessageBox.Show("Selecione um livro na tabela primeiro!");
                return;
            }

            if (novaQtdTotal <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que zero!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int novaDispCalculada = dao.CalcularNovaDisponibilidade(idAtual, novaQtdTotal);

            if (novaDispCalculada < 0)
            {
                int qtdEmprestada = novaQtdTotal - novaDispCalculada;
                MessageBox.Show($"Erro: Existem livros emprestados. O estoque total mínimo deve ser {novaQtdTotal - novaDispCalculada}.");
                return;
            }

            int idExistente = dao.ObterIdLivro(novoTitulo, novoAutor, novoAnoPublicacao);
            if (idExistente > 0 && idExistente != idAtual)
            {
                MessageBox.Show("Já existe outro livro com estes dados cadastrados!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string erro = dao.EditarLivro(idAtual, novoTitulo, novoAutor, novoAnoPublicacao, novaQtdTotal, novaDispCalculada);

            if (erro == null)
            {
                MessageBox.Show("Livro editado com sucesso!");
                AtualizarGrade();
                LimparCampos();
            }
            else
            {
                MessageBox.Show(erro);
            }
        }

        private void dgvLivros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dgvLivros.Rows[e.RowIndex];

                labIdLivro.Text = linha.Cells["idLivro"].Value.ToString();
                txtAutor.Text = linha.Cells["autor"].Value.ToString();
                txtTitulo.Text = linha.Cells["titulo"].Value.ToString();
                numAno.Value = Convert.ToDecimal(linha.Cells["anoPublica"].Value);
                numQtdDisp.Value = Convert.ToDecimal(linha.Cells["qtdDisp"].Value);
                numQtdTotal.Value = Convert.ToDecimal(linha.Cells["qtdTotal"].Value);

            }
        }

        private void btnExcluirLivro_Click(object sender, EventArgs e)
        {
            int idSelecionado = int.Parse(labIdLivro.Text);
            int qtdParaRemover = (int)numQtdTotal.Value;

            if (idSelecionado <= 0 || qtdParaRemover <= 0 || labIdLivro.Text == "0")
            {
                MessageBox.Show("Selecione um livro e uma quantidade válida.");
                return;
            }

            DialogResult confirma = MessageBox.Show($"Deseja remover {qtdParaRemover} unidade(s) do estoque?",
                "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirma == DialogResult.Yes)
            {
                string erro = dao.ExcluirLivro(idSelecionado, qtdParaRemover);

                if (erro == null)
                {
                    MessageBox.Show("Estoque atualizado com sucesso!");
                    AtualizarGrade();
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show(erro, "Aviso de Estoque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCadastrarLivro_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposObrigatorios()) return;

            int idAtual = int.Parse(labIdLivro.Text);
            string titulo = txtTitulo.Text.Trim();
            string autor = txtAutor.Text.Trim();
            int anoPublica = (int)numAno.Value;
            int qtdDigitada = (int)numQtdTotal.Value;
            int novaQtd = (int)numQtdTotal.Value;
            int qtdDisp = (int)numQtdDisp.Value + novaQtd;

            if (qtdDigitada <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que zero!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idExistente = dao.ObterIdLivro(titulo, autor, anoPublica);

                if (idExistente > 0)
                {
                    DataTable dt = dao.BuscarLivroPorId(idExistente);

                    if (dt.Rows.Count > 0)
                    {
                        int totalAtual = Convert.ToInt32(dt.Rows[0]["qtdTotal"]);
                        int dispAtual = Convert.ToInt32(dt.Rows[0]["qtdDisp"]);

                        int novoTotal = totalAtual + qtdDigitada;

                        dao.EditarLivro(idExistente, titulo, autor, anoPublica, novoTotal, qtdDisp);
                        MessageBox.Show($"Foram adicionadas {qtdDigitada} unidades ao livro '{titulo}'.\nO estoque agora é de {novoTotal} unidades.", "Estoque Atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    dao.CadastrarLivro(titulo, autor, anoPublica, qtdDigitada, qtdDigitada);
                    MessageBox.Show("Livro cadastrado com sucesso!");
                }

                AtualizarGrade();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
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