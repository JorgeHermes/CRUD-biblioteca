namespace CRUDbiblioteca
{
    partial class FrmCliente
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
            this.atualizar = new System.Windows.Forms.Button();
            this.cadastrar = new System.Windows.Forms.Button();
            this.excluir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // atualizar
            // 
            this.atualizar.Location = new System.Drawing.Point(317, 227);
            this.atualizar.Name = "atualizar";
            this.atualizar.Size = new System.Drawing.Size(220, 23);
            this.atualizar.TabIndex = 0;
            this.atualizar.Text = "ATUALIZAR";
            this.atualizar.UseVisualStyleBackColor = true;
            this.atualizar.Click += new System.EventHandler(this.atualizar_Click);
            // 
            // cadastrar
            // 
            this.cadastrar.Location = new System.Drawing.Point(317, 198);
            this.cadastrar.Name = "cadastrar";
            this.cadastrar.Size = new System.Drawing.Size(220, 23);
            this.cadastrar.TabIndex = 1;
            this.cadastrar.Text = "CADASTRAR";
            this.cadastrar.UseVisualStyleBackColor = true;
            this.cadastrar.Click += new System.EventHandler(this.cadastrar_Click);
            // 
            // excluir
            // 
            this.excluir.Location = new System.Drawing.Point(317, 256);
            this.excluir.Name = "excluir";
            this.excluir.Size = new System.Drawing.Size(220, 23);
            this.excluir.TabIndex = 2;
            this.excluir.Text = "EXCLUIR";
            this.excluir.UseVisualStyleBackColor = true;
            this.excluir.Click += new System.EventHandler(this.excluir_Click);
            // 
            // FrmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 485);
            this.Controls.Add(this.excluir);
            this.Controls.Add(this.cadastrar);
            this.Controls.Add(this.atualizar);
            this.Name = "FrmCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CLIENTES";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button atualizar;
        private System.Windows.Forms.Button cadastrar;
        private System.Windows.Forms.Button excluir;
    }
}