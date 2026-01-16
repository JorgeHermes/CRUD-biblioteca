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

        public FrmLivros()
        {
            InitializeComponent();
            AtualizarGrade();
        }
        private void LimparCampos() 
        {
            txtAutor.Clear();
            txtTitulo.Clear();
            numQtdTotal.Value = 0;
            numQtdDisp.Value = 0;
        }

        private void AtualizarGrade()
        {
            try 
            {
                funcoesLivro dao = new funcoesLivro();
                dgvLivros.DataSource = dao.ListarLivro();
                dgvLivros.Columns["idLivro"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);           
            }
        }

        private bool ValidarCamposObrigatorios()
        {
            if (string.IsNullOrWhiteSpace(txtAutor.Text))
            {
                MessageBox.Show("O autor é obrigatório.");
                txtAutor.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("O título é necessário para organizarmos o estoque!");
                txtTitulo.Focus();
                return true;
            }

            return false;
        }

        private void btnListarLivro_Click(object sender, EventArgs e)
        {
            AtualizarGrade();
            LimparCampos();
        }

        private void btnEditarLivro_Click(object sender, EventArgs e)
        {
            funcoesLivro dao = new funcoesLivro();

            int idAtual = int.Parse(labIdLivro.Text); 
            string novoTitulo = txtTitulo.Text.Trim();
            string novoAutor = txtAutor.Text.Trim();
            int novoAnoPublicacao = int.Parse(numAno.Value.ToString());
            int qtdDigitada = (int)numQtdTotal.Value;
            DataTable dt = dao.BuscarLivroPorId(idAtual);

            if (qtdDigitada <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que zero!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            if (dt.Rows.Count > 0)
            {
                int totalNoBanco = Convert.ToInt32(dt.Rows[0]["qtdTotal"]);
                int dispNoBanco = Convert.ToInt32(dt.Rows[0]["qtdDisp"]);
                int qtdEmprestada = totalNoBanco - dispNoBanco;

                if (qtdDigitada < qtdEmprestada)
                {
                    MessageBox.Show($"Erro: Você não pode reduzir o estoque para {qtdDigitada} porque existem {qtdEmprestada} livros emprestados.");
                    return;
                }
            }

            int idLivro = dao.ValidacaoCadastro(novoTitulo, novoAutor, novoAnoPublicacao);

            if (idLivro > 0)
            {
                MessageBox.Show("Já existe outro livro com este cadastrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string erro = dao.EditarLivro(idAtual, novoTitulo, txtAutor.Text.Trim(), (int)numAno.Value, (int)numQtdTotal.Value);

            if (erro == null)
            {
                MessageBox.Show("Livro editado com sucesso!");
                AtualizarGrade();
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

            }
        }

        private void btnExcluirLivro_Click(object sender, EventArgs e)
        {
            int idLivroSelecionado = int.Parse(labIdLivro.Text);
            if (idLivroSelecionado == 0)
            {
                MessageBox.Show("Por favor, selecione um livro na tabela primeiro.");
                return;
            }

            if (numQtdTotal.Value == 0) 
            {
                MessageBox.Show("Por favor, selecione a quantidade desejada.");
                return;
            }

            int qtdParaRemover = (int)numQtdTotal.Value;

            DialogResult confirma = MessageBox.Show($"Deseja remover {qtdParaRemover} unidade(s) deste livro?",
                "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirma == DialogResult.Yes)
            {
                funcoesLivro dao = new funcoesLivro();

                string erro = dao.ExcluirLivro(idLivroSelecionado, qtdParaRemover);

                if (erro == null)
                {
                    MessageBox.Show("Estoque atualizado com sucesso!");
                    AtualizarGrade();
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show(erro);
                }
            }
        }

        private void btnCadastrarLivro_Click(object sender, EventArgs e)
        {
            if (ValidarCamposObrigatorios()) return;

            funcoesLivro dao = new funcoesLivro();
            string titulo = txtTitulo.Text.Trim();
            string autor = txtAutor.Text.Trim();
            int anoPublica = (int)numAno.Value;
            int qtdDigitada = (int)numQtdTotal.Value;

            if (qtdDigitada <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que zero!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idExistente = dao.ValidacaoCadastro(titulo, autor, anoPublica);

                if (idExistente > 0)
                {
                    DataTable dt = dao.BuscarLivroPorId(idExistente);

                    if (dt.Rows.Count > 0)
                    {
                        int totalAtual = Convert.ToInt32(dt.Rows[0]["qtdTotal"]);
                        int dispAtual = Convert.ToInt32(dt.Rows[0]["qtdDisp"]);

                        int novoTotal = totalAtual + qtdDigitada;

                        dao.EditarLivro(idExistente, titulo, autor, anoPublica, novoTotal);
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
