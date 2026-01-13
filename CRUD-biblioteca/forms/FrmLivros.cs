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
    public partial class FrmLivros : Form
    {
        private static readonly (string chave, string titulo)[] ColunasGrid =
        {
            ("idLivro", "Código"),
            ("titulo", "Título do Livro"),
            ("autor", "Autor"),
            ("anoPublica", "Ano"),
            ("qtdTotal", "Total"),
            ("qtdDisp", "Disponível")
        };

        public FrmLivros()
        {
            InitializeComponent();
        }

        private void FrmLivros_Load(object sender, EventArgs e)
        {
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
                ConfigurarGridLivros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);           
            }
        }

        private void ConfigurarGridLivros()
        {
            if (dgvLivros.Columns.Contains("idLivro"))
                dgvLivros.Columns["idLivro"].Visible = false;

            foreach ((string chave, string titulo) in ColunasGrid)
            {
                if (dgvLivros.Columns.Contains(chave))
                {
                    dgvLivros.Columns[chave].HeaderText = titulo;
                }
            }
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
            if (!ValidarCamposObrigatorios()) return;

            int id = int.Parse(labIdLivro.Text);

            funcoesLivro dao = new funcoesLivro();

            string resultado = dao.EditarLivro(id, txtTitulo.Text, txtAutor.Text, (int)numAno.Value, (int)numQtdTotal.Value);

            if (resultado == null)
            {
                MessageBox.Show("Livro atualizado!");
                AtualizarGrade();
                LimparCampos();
            }
            else
            {
                MessageBox.Show(resultado);
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
            if (!ValidarCamposObrigatorios()) return;

            funcoesLivro dao = new funcoesLivro();
            string titulo = txtTitulo.Text;
            string autor = txtAutor.Text;
            int anoPublica = (int)numAno.Value;
            int qtdDigitada = (int)numQtdTotal.Value;

            if (qtdDigitada <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que zero!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idExistente = dao.ObterIdExisteNoBancoLivro(titulo, autor, anoPublica);

            if (idExistente > 0)
            {
                DataTable dt = dao.BuscarLivroPorId(idExistente);
                int totalAtualNoBanco = Convert.ToInt32(dt.Rows[0]["qtdTotal"]);
                int novoTotalAcumulado = totalAtualNoBanco + qtdDigitada;

                dao.EditarLivro(idExistente, titulo, autor, anoPublica, novoTotalAcumulado);

                MessageBox.Show($"O livro '{titulo}' já existia. Estoque atualizado para {novoTotalAcumulado} unidades.");

                AtualizarGrade();
                LimparCampos();
                return;
            }

            dao.CadastrarLivro(titulo, autor, anoPublica, qtdDigitada, qtdDigitada);
            MessageBox.Show("Livro cadastrado com sucesso!");

            AtualizarGrade();
            LimparCampos();
        }
    }
    }
