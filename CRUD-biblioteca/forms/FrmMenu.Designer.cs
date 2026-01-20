using System.Drawing;

namespace CRUDbiblioteca.forms
{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.labTitulo = new System.Windows.Forms.Label();
            this.panelBtn = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEmp = new System.Windows.Forms.Button();
            this.btnLivros = new System.Windows.Forms.Button();
            this.btnCLientes = new System.Windows.Forms.Button();
            this.panelTitulo.SuspendLayout();
            this.panelBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitulo
            // 
            this.panelTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelTitulo.Controls.Add(this.labTitulo);
            this.panelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelTitulo.Location = new System.Drawing.Point(0, 12);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(670, 69);
            this.panelTitulo.TabIndex = 0;
            // 
            // labTitulo
            // 
            this.labTitulo.AutoSize = true;
            this.labTitulo.Font = new System.Drawing.Font("Segoe UI Symbol", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitulo.Location = new System.Drawing.Point(235, 7);
            this.labTitulo.Name = "labTitulo";
            this.labTitulo.Size = new System.Drawing.Size(206, 54);
            this.labTitulo.TabIndex = 0;
            this.labTitulo.Text = "Biblioteca";
            this.labTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBtn
            // 
            this.panelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBtn.BackColor = System.Drawing.SystemColors.Control;
            this.panelBtn.Controls.Add(this.label3);
            this.panelBtn.Controls.Add(this.label2);
            this.panelBtn.Controls.Add(this.label1);
            this.panelBtn.Controls.Add(this.btnEmp);
            this.panelBtn.Controls.Add(this.btnLivros);
            this.panelBtn.Controls.Add(this.btnCLientes);
            this.panelBtn.Location = new System.Drawing.Point(12, 149);
            this.panelBtn.Name = "panelBtn";
            this.panelBtn.Size = new System.Drawing.Size(645, 144);
            this.panelBtn.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(523, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Empresimos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(301, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Livros";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Clientes";
            // 
            // btnEmp
            // 
            this.btnEmp.BackgroundImage = global::CRUDbiblioteca.Properties.Resources.apple_touch_icon3;
            this.btnEmp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEmp.FlatAppearance.BorderSize = 0;
            this.btnEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmp.Location = new System.Drawing.Point(504, 22);
            this.btnEmp.Name = "btnEmp";
            this.btnEmp.Size = new System.Drawing.Size(100, 100);
            this.btnEmp.TabIndex = 2;
            this.btnEmp.UseVisualStyleBackColor = true;
            this.btnEmp.Click += new System.EventHandler(this.btnEmprestimos_Click);
            // 
            // btnLivros
            // 
            this.btnLivros.BackgroundImage = global::CRUDbiblioteca.Properties.Resources.apple_touch_icon2;
            this.btnLivros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLivros.FlatAppearance.BorderSize = 0;
            this.btnLivros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLivros.Location = new System.Drawing.Point(267, 22);
            this.btnLivros.Name = "btnLivros";
            this.btnLivros.Size = new System.Drawing.Size(100, 100);
            this.btnLivros.TabIndex = 1;
            this.btnLivros.UseVisualStyleBackColor = true;
            this.btnLivros.Click += new System.EventHandler(this.btnLivros_Click);
            // 
            // btnCLientes
            // 
            this.btnCLientes.BackgroundImage = global::CRUDbiblioteca.Properties.Resources.android_chrome_192x192;
            this.btnCLientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCLientes.FlatAppearance.BorderSize = 0;
            this.btnCLientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCLientes.Location = new System.Drawing.Point(43, 22);
            this.btnCLientes.Name = "btnCLientes";
            this.btnCLientes.Size = new System.Drawing.Size(100, 100);
            this.btnCLientes.TabIndex = 0;
            this.btnCLientes.UseVisualStyleBackColor = true;
            this.btnCLientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(669, 393);
            this.Controls.Add(this.panelBtn);
            this.Controls.Add(this.panelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelBtn.ResumeLayout(false);
            this.panelBtn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Panel panelBtn;
        private System.Windows.Forms.Label labTitulo;
        private System.Windows.Forms.Button btnEmp;
        private System.Windows.Forms.Button btnLivros;
        private System.Windows.Forms.Button btnCLientes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}