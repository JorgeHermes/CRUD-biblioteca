namespace CRUDbiblioteca
{
    partial class FrmLivros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLivros));
            this.dgvLivros = new System.Windows.Forms.DataGridView();
            this.btnExcluirLivro = new System.Windows.Forms.Button();
            this.btnEditarLivro = new System.Windows.Forms.Button();
            this.btnCadastrarLivro = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numAno = new System.Windows.Forms.NumericUpDown();
            this.numQtdDisp = new System.Windows.Forms.NumericUpDown();
            this.numQtdTotal = new System.Windows.Forms.NumericUpDown();
            this.total = new System.Windows.Forms.Label();
            this.labIdLivro = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.Autor = new System.Windows.Forms.Label();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.Ano = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.qtddisp = new System.Windows.Forms.Label();
            this.btnListarLivro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivros)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdDisp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLivros
            // 
            this.dgvLivros.AllowUserToAddRows = false;
            this.dgvLivros.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvLivros.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLivros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLivros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLivros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLivros.ColumnHeadersHeight = 30;
            this.dgvLivros.Location = new System.Drawing.Point(12, 169);
            this.dgvLivros.Name = "dgvLivros";
            this.dgvLivros.ReadOnly = true;
            this.dgvLivros.Size = new System.Drawing.Size(778, 285);
            this.dgvLivros.TabIndex = 6;
            this.dgvLivros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLivros_CellClick);
            // 
            // btnExcluirLivro
            // 
            this.btnExcluirLivro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnExcluirLivro.FlatAppearance.BorderSize = 0;
            this.btnExcluirLivro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirLivro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirLivro.Location = new System.Drawing.Point(594, 118);
            this.btnExcluirLivro.Name = "btnExcluirLivro";
            this.btnExcluirLivro.Size = new System.Drawing.Size(161, 23);
            this.btnExcluirLivro.TabIndex = 9;
            this.btnExcluirLivro.Text = "Excluir";
            this.btnExcluirLivro.UseVisualStyleBackColor = false;
            this.btnExcluirLivro.Click += new System.EventHandler(this.btnExcluirLivro_Click);
            // 
            // btnEditarLivro
            // 
            this.btnEditarLivro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnEditarLivro.FlatAppearance.BorderSize = 0;
            this.btnEditarLivro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarLivro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarLivro.Location = new System.Drawing.Point(594, 79);
            this.btnEditarLivro.Name = "btnEditarLivro";
            this.btnEditarLivro.Size = new System.Drawing.Size(161, 23);
            this.btnEditarLivro.TabIndex = 8;
            this.btnEditarLivro.Text = "Editar";
            this.btnEditarLivro.UseVisualStyleBackColor = false;
            this.btnEditarLivro.Click += new System.EventHandler(this.btnEditarLivro_Click);
            // 
            // btnCadastrarLivro
            // 
            this.btnCadastrarLivro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnCadastrarLivro.FlatAppearance.BorderSize = 0;
            this.btnCadastrarLivro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrarLivro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarLivro.Location = new System.Drawing.Point(594, 36);
            this.btnCadastrarLivro.Name = "btnCadastrarLivro";
            this.btnCadastrarLivro.Size = new System.Drawing.Size(161, 23);
            this.btnCadastrarLivro.TabIndex = 7;
            this.btnCadastrarLivro.Text = "Cadastrar";
            this.btnCadastrarLivro.UseVisualStyleBackColor = false;
            this.btnCadastrarLivro.Click += new System.EventHandler(this.btnCadastrarLivro_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.numAno);
            this.groupBox2.Controls.Add(this.numQtdDisp);
            this.groupBox2.Controls.Add(this.numQtdTotal);
            this.groupBox2.Controls.Add(this.total);
            this.groupBox2.Controls.Add(this.labIdLivro);
            this.groupBox2.Controls.Add(this.txtTitulo);
            this.groupBox2.Controls.Add(this.Autor);
            this.groupBox2.Controls.Add(this.txtAutor);
            this.groupBox2.Controls.Add(this.Ano);
            this.groupBox2.Controls.Add(this.labelTitulo);
            this.groupBox2.Controls.Add(this.qtddisp);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 149);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados Livro";
            // 
            // numAno
            // 
            this.numAno.Location = new System.Drawing.Point(421, 33);
            this.numAno.Maximum = new decimal(new int[] {
            2026,
            0,
            0,
            0});
            this.numAno.Minimum = new decimal(new int[] {
            1400,
            0,
            0,
            -2147483648});
            this.numAno.Name = "numAno";
            this.numAno.Size = new System.Drawing.Size(120, 20);
            this.numAno.TabIndex = 26;
            // 
            // numQtdDisp
            // 
            this.numQtdDisp.Enabled = false;
            this.numQtdDisp.Location = new System.Drawing.Point(421, 62);
            this.numQtdDisp.Name = "numQtdDisp";
            this.numQtdDisp.Size = new System.Drawing.Size(120, 20);
            this.numQtdDisp.TabIndex = 25;
            // 
            // numQtdTotal
            // 
            this.numQtdTotal.Location = new System.Drawing.Point(280, 99);
            this.numQtdTotal.Name = "numQtdTotal";
            this.numQtdTotal.Size = new System.Drawing.Size(120, 20);
            this.numQtdTotal.TabIndex = 24;
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Location = new System.Drawing.Point(183, 102);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(91, 13);
            this.total.TabIndex = 20;
            this.total.Text = "Quantidade total :";
            this.total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labIdLivro
            // 
            this.labIdLivro.AutoSize = true;
            this.labIdLivro.Location = new System.Drawing.Point(25, 106);
            this.labIdLivro.Name = "labIdLivro";
            this.labIdLivro.Size = new System.Drawing.Size(13, 13);
            this.labIdLivro.TabIndex = 19;
            this.labIdLivro.Text = "0";
            this.labIdLivro.Visible = false;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(72, 32);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(202, 20);
            this.txtTitulo.TabIndex = 7;
            // 
            // Autor
            // 
            this.Autor.AutoSize = true;
            this.Autor.Location = new System.Drawing.Point(16, 65);
            this.Autor.Name = "Autor";
            this.Autor.Size = new System.Drawing.Size(38, 13);
            this.Autor.TabIndex = 10;
            this.Autor.Text = "Autor :";
            this.Autor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(72, 62);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(202, 20);
            this.txtAutor.TabIndex = 8;
            // 
            // Ano
            // 
            this.Ano.AutoSize = true;
            this.Ano.Location = new System.Drawing.Point(297, 35);
            this.Ano.Name = "Ano";
            this.Ano.Size = new System.Drawing.Size(102, 13);
            this.Ano.TabIndex = 15;
            this.Ano.Text = "Ano de publicação :";
            this.Ano.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Location = new System.Drawing.Point(16, 35);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(41, 13);
            this.labelTitulo.TabIndex = 6;
            this.labelTitulo.Text = "Título :";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // qtddisp
            // 
            this.qtddisp.AutoSize = true;
            this.qtddisp.Location = new System.Drawing.Point(297, 65);
            this.qtddisp.Name = "qtddisp";
            this.qtddisp.Size = new System.Drawing.Size(118, 13);
            this.qtddisp.TabIndex = 11;
            this.qtddisp.Text = "Quantidade disponivel :";
            this.qtddisp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnListarLivro
            // 
            this.btnListarLivro.Image = global::CRUDbiblioteca.Properties.Resources.favicon_16x16;
            this.btnListarLivro.Location = new System.Drawing.Point(765, 3);
            this.btnListarLivro.Name = "btnListarLivro";
            this.btnListarLivro.Size = new System.Drawing.Size(25, 25);
            this.btnListarLivro.TabIndex = 21;
            this.btnListarLivro.UseVisualStyleBackColor = true;
            this.btnListarLivro.Click += new System.EventHandler(this.btnListarLivro_Click);
            // 
            // FrmLivros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 466);
            this.Controls.Add(this.btnListarLivro);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnExcluirLivro);
            this.Controls.Add(this.btnEditarLivro);
            this.Controls.Add(this.btnCadastrarLivro);
            this.Controls.Add(this.dgvLivros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLivros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Livros";
            this.Load += new System.EventHandler(this.FrmLivros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivros)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdDisp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdTotal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLivros;
        private System.Windows.Forms.Button btnExcluirLivro;
        private System.Windows.Forms.Button btnEditarLivro;
        private System.Windows.Forms.Button btnCadastrarLivro;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labIdLivro;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label Autor;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.Label Ano;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label qtddisp;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Button btnListarLivro;
        private System.Windows.Forms.NumericUpDown numAno;
        private System.Windows.Forms.NumericUpDown numQtdTotal;
        private System.Windows.Forms.NumericUpDown numQtdDisp;
    }
}