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

            if (numQtdTotal.Value <= 0)
            {
                MessageBox.Show("A quantidade total deve ser pelo menos 1!");
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
                numQtdTotal.Value = Convert.ToDecimal(linha.Cells["qtdTotal"].Value);

            }
        }

        private void btnExcluirLivro_Click(object sender, EventArgs e)
        {
            if (dgvLivros.CurrentRow==null)
            {
                MessageBox.Show("Selecione um livro na grade primeiro.");
                return;
            }

            DialogResult confirmacao = MessageBox.Show("Deseja realmente excluir este livro?", "Confirmação", MessageBoxButtons.YesNo);

            if (confirmacao == DialogResult.Yes)
            {
                try
                {
                    int idSelecionado = Convert.ToInt32(dgvLivros.CurrentRow.Cells[0].Value);

                    funcoesLivro dao = new funcoesLivro();
                    string erro = dao.ExcluirLivro(idSelecionado);

                    if (erro == null)
                    {
                        MessageBox.Show("Livro excluído com sucesso!");
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

        private void btnCadastrarLivro_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposObrigatorios()) return;

            funcoesLivro dao = new funcoesLivro();
            string titulo = txtTitulo.Text;
            string autor = txtAutor.Text;
            int anoPublica = (int)numAno.Value;
            int qtdDigitada = (int)numQtdTotal.Value;

            int idExistente = dao.ObterIdExisteNoBancoLivro(titulo, autor, anoPublica);

            if (idExistente > 0)
            {
                DataTable dt = dao.BuscarLivroPorId(idExistente);
                int totalAtualNoBanco = Convert.ToInt32(dt.Rows[0]["qtdTotal"]);

                int novoTotalAcumulado = totalAtualNoBanco + qtdDigitada;

                dao.EditarLivro(idExistente, titulo, autor, (int)numAno.Value, novoTotalAcumulado);

                MessageBox.Show($"O livro '{titulo}' já existia. Estoque atualizado para {novoTotalAcumulado} unidades.");
            }
            else
            {
                dao.CadastrarLivro(titulo, autor, (int)numAno.Value, qtdDigitada, qtdDigitada);
                MessageBox.Show("Livro cadastrado com sucesso!");
            }

            AtualizarGrade();
            LimparCampos();
        }

    }
    }
