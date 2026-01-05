using CRUDbiblioteca;

namespace WindowsFormsApp1
{
    partial class FrmIndex
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
            this.tabPageClientes = new System.Windows.Forms.TabControl();
            this.clientes = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPageClientes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageClientes
            // 
            this.tabPageClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPageClientes.Controls.Add(this.clientes);
            this.tabPageClientes.Controls.Add(this.tabPage1);
            this.tabPageClientes.Location = new System.Drawing.Point(1, 0);
            this.tabPageClientes.Name = "tabPageClientes";
            this.tabPageClientes.SelectedIndex = 0;
            this.tabPageClientes.Size = new System.Drawing.Size(862, 485);
            this.tabPageClientes.TabIndex = 3;
            // 
            // clientes
            // 
            this.clientes.Location = new System.Drawing.Point(4, 22);
            this.clientes.Name = "clientes";
            this.clientes.Size = new System.Drawing.Size(854, 459);
            this.clientes.TabIndex = 0;
            this.clientes.Text = "CLIENTES";
            this.clientes.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(877, 401);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // FrmIndex
            // 
            this.AccessibleName = "FrmIndex";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 485);
            this.Controls.Add(this.tabPageClientes);
            this.Name = "FrmIndex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INDEX";
            this.tabPageClientes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabPageClientes;
        private System.Windows.Forms.TabPage clientes;
        private System.Windows.Forms.TabPage tabPage1;
    }
}

