namespace CRUDbiblioteca.forms
{
    partial class FrmEmprestimos
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmprestimos));
            this.dgvEmprestimos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labIdClienteEmp = new System.Windows.Forms.Label();
            this.labIdLivroEmp = new System.Windows.Forms.Label();
            this.labIdEmprestimo = new System.Windows.Forms.Label();
            this.dataEmprestimo = new System.Windows.Forms.DateTimePicker();
            this.dataDevolucao = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataPrevisaoDevolucao = new System.Windows.Forms.DateTimePicker();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.dgvLivrosEmprestimos = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labIdLivro = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataPrevista1 = new System.Windows.Forms.DateTimePicker();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirmarEmprestimo = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnListarEmprestimo = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprestimos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivrosEmprestimos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEmprestimos
            // 
            this.dgvEmprestimos.AllowUserToAddRows = false;
            this.dgvEmprestimos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvEmprestimos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmprestimos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmprestimos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEmprestimos.ColumnHeadersHeight = 30;
            this.dgvEmprestimos.Location = new System.Drawing.Point(444, 209);
            this.dgvEmprestimos.Name = "dgvEmprestimos";
            this.dgvEmprestimos.ReadOnly = true;
            this.dgvEmprestimos.Size = new System.Drawing.Size(504, 367);
            this.dgvEmprestimos.TabIndex = 7;
            this.dgvEmprestimos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmprestimos_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labIdClienteEmp);
            this.groupBox1.Controls.Add(this.labIdLivroEmp);
            this.groupBox1.Controls.Add(this.labIdEmprestimo);
            this.groupBox1.Controls.Add(this.dataEmprestimo);
            this.groupBox1.Controls.Add(this.dataDevolucao);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dataPrevisaoDevolucao);
            this.groupBox1.Controls.Add(this.btnEditar);
            this.groupBox1.Controls.Add(this.btnDevolver);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(444, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 143);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Emprestimos Realizado";
            // 
            // labIdClienteEmp
            // 
            this.labIdClienteEmp.AutoSize = true;
            this.labIdClienteEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labIdClienteEmp.Location = new System.Drawing.Point(55, 119);
            this.labIdClienteEmp.Name = "labIdClienteEmp";
            this.labIdClienteEmp.Size = new System.Drawing.Size(13, 13);
            this.labIdClienteEmp.TabIndex = 38;
            this.labIdClienteEmp.Text = "0";
            this.labIdClienteEmp.Visible = false;
            // 
            // labIdLivroEmp
            // 
            this.labIdLivroEmp.AutoSize = true;
            this.labIdLivroEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labIdLivroEmp.Location = new System.Drawing.Point(36, 119);
            this.labIdLivroEmp.Name = "labIdLivroEmp";
            this.labIdLivroEmp.Size = new System.Drawing.Size(13, 13);
            this.labIdLivroEmp.TabIndex = 37;
            this.labIdLivroEmp.Text = "0";
            this.labIdLivroEmp.Visible = false;
            // 
            // labIdEmprestimo
            // 
            this.labIdEmprestimo.AutoSize = true;
            this.labIdEmprestimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labIdEmprestimo.Location = new System.Drawing.Point(16, 119);
            this.labIdEmprestimo.Name = "labIdEmprestimo";
            this.labIdEmprestimo.Size = new System.Drawing.Size(13, 13);
            this.labIdEmprestimo.TabIndex = 35;
            this.labIdEmprestimo.Text = "0";
            this.labIdEmprestimo.Visible = false;
            // 
            // dataEmprestimo
            // 
            this.dataEmprestimo.Enabled = false;
            this.dataEmprestimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataEmprestimo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataEmprestimo.Location = new System.Drawing.Point(118, 25);
            this.dataEmprestimo.Name = "dataEmprestimo";
            this.dataEmprestimo.Size = new System.Drawing.Size(96, 20);
            this.dataEmprestimo.TabIndex = 31;
            // 
            // dataDevolucao
            // 
            this.dataDevolucao.Enabled = false;
            this.dataDevolucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataDevolucao.Location = new System.Drawing.Point(131, 82);
            this.dataDevolucao.Name = "dataDevolucao";
            this.dataDevolucao.Size = new System.Drawing.Size(96, 20);
            this.dataDevolucao.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Data de Devolução : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Data Prevista de Devolução : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Data Emprestimo : ";
            // 
            // dataPrevisaoDevolucao
            // 
            this.dataPrevisaoDevolucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPrevisaoDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataPrevisaoDevolucao.Location = new System.Drawing.Point(172, 54);
            this.dataPrevisaoDevolucao.Name = "dataPrevisaoDevolucao";
            this.dataPrevisaoDevolucao.Size = new System.Drawing.Size(96, 20);
            this.dataPrevisaoDevolucao.TabIndex = 26;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Image = global::CRUDbiblioteca.Properties.Resources.favicon_16x163;
            this.btnEditar.Location = new System.Drawing.Point(397, 50);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 25;
            this.toolTip.SetToolTip(this.btnEditar, "Editar");
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnDevolver
            // 
            this.btnDevolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDevolver.FlatAppearance.BorderSize = 0;
            this.btnDevolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevolver.Image = global::CRUDbiblioteca.Properties.Resources.favicon_16x168;
            this.btnDevolver.Location = new System.Drawing.Point(397, 79);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(75, 23);
            this.btnDevolver.TabIndex = 24;
            this.toolTip.SetToolTip(this.btnDevolver, "Devolver");
            this.btnDevolver.UseVisualStyleBackColor = false;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // dgvLivrosEmprestimos
            // 
            this.dgvLivrosEmprestimos.AllowUserToAddRows = false;
            this.dgvLivrosEmprestimos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvLivrosEmprestimos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLivrosEmprestimos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLivrosEmprestimos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLivrosEmprestimos.ColumnHeadersHeight = 30;
            this.dgvLivrosEmprestimos.Location = new System.Drawing.Point(12, 209);
            this.dgvLivrosEmprestimos.Name = "dgvLivrosEmprestimos";
            this.dgvLivrosEmprestimos.ReadOnly = true;
            this.dgvLivrosEmprestimos.Size = new System.Drawing.Size(409, 367);
            this.dgvLivrosEmprestimos.TabIndex = 27;
            this.dgvLivrosEmprestimos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLivrosEmprestimos_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labIdLivro);
            this.groupBox2.Controls.Add(this.cmbCliente);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dataPrevista1);
            this.groupBox2.Controls.Add(this.txtAno);
            this.groupBox2.Controls.Add(this.txtAutor);
            this.groupBox2.Controls.Add(this.txtTitulo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnConfirmarEmprestimo);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 181);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados Emprestimo";
            // 
            // labIdLivro
            // 
            this.labIdLivro.AutoSize = true;
            this.labIdLivro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labIdLivro.Location = new System.Drawing.Point(286, 148);
            this.labIdLivro.Name = "labIdLivro";
            this.labIdLivro.Size = new System.Drawing.Size(13, 13);
            this.labIdLivro.TabIndex = 34;
            this.labIdLivro.Text = "0";
            this.labIdLivro.Visible = false;
            // 
            // cmbCliente
            // 
            this.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(64, 25);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(151, 21);
            this.cmbCliente.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Cliente :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Data Prevista de Devolução :";
            // 
            // dataPrevista1
            // 
            this.dataPrevista1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPrevista1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataPrevista1.Location = new System.Drawing.Point(158, 148);
            this.dataPrevista1.Name = "dataPrevista1";
            this.dataPrevista1.Size = new System.Drawing.Size(96, 20);
            this.dataPrevista1.TabIndex = 30;
            // 
            // txtAno
            // 
            this.txtAno.Enabled = false;
            this.txtAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAno.Location = new System.Drawing.Point(115, 114);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(100, 20);
            this.txtAno.TabIndex = 29;
            // 
            // txtAutor
            // 
            this.txtAutor.Enabled = false;
            this.txtAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutor.Location = new System.Drawing.Point(50, 82);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(249, 20);
            this.txtAutor.TabIndex = 28;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Enabled = false;
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(51, 53);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(248, 20);
            this.txtTitulo.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Ano de Publicação : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Autor : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Titulo : ";
            // 
            // btnConfirmarEmprestimo
            // 
            this.btnConfirmarEmprestimo.BackColor = System.Drawing.Color.DarkGray;
            this.btnConfirmarEmprestimo.FlatAppearance.BorderSize = 0;
            this.btnConfirmarEmprestimo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarEmprestimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarEmprestimo.Image = global::CRUDbiblioteca.Properties.Resources.favicon_16x166;
            this.btnConfirmarEmprestimo.Location = new System.Drawing.Point(328, 152);
            this.btnConfirmarEmprestimo.Name = "btnConfirmarEmprestimo";
            this.btnConfirmarEmprestimo.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmarEmprestimo.TabIndex = 23;
            this.toolTip.SetToolTip(this.btnConfirmarEmprestimo, "Confirmar");
            this.btnConfirmarEmprestimo.UseVisualStyleBackColor = false;
            this.btnConfirmarEmprestimo.Click += new System.EventHandler(this.btnConfirmarEmprestimo_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(873, 582);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltar.TabIndex = 29;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnListarEmprestimo
            // 
            this.btnListarEmprestimo.Image = global::CRUDbiblioteca.Properties.Resources.favicon_16x16;
            this.btnListarEmprestimo.Location = new System.Drawing.Point(923, 3);
            this.btnListarEmprestimo.Name = "btnListarEmprestimo";
            this.btnListarEmprestimo.Size = new System.Drawing.Size(25, 25);
            this.btnListarEmprestimo.TabIndex = 22;
            this.btnListarEmprestimo.UseVisualStyleBackColor = true;
            this.btnListarEmprestimo.Click += new System.EventHandler(this.btnListarEmprestimo_Click);
            // 
            // FrmEmprestimos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 610);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvLivrosEmprestimos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnListarEmprestimo);
            this.Controls.Add(this.dgvEmprestimos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEmprestimos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emprestimos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprestimos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivrosEmprestimos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmprestimos;
        private System.Windows.Forms.Button btnListarEmprestimo;
        private System.Windows.Forms.Button btnConfirmarEmprestimo;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvLivrosEmprestimos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.DateTimePicker dataEmprestimo;
        private System.Windows.Forms.DateTimePicker dataDevolucao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dataPrevisaoDevolucao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dataPrevista1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label labIdEmprestimo;
        private System.Windows.Forms.Label labIdLivro;
        private System.Windows.Forms.Label labIdLivroEmp;
        private System.Windows.Forms.Label labIdClienteEmp;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.ToolTip toolTip;
    }
}