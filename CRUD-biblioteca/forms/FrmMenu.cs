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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        private void btnLivros_Click(object sender, EventArgs e)
        {
            FrmLivros telaLivros = new FrmLivros();
            telaLivros.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmClientes telaClientes = new FrmClientes();
            telaClientes.Show();
        }

        private void btnEmprestimos_Click(object sender, EventArgs e)
        {
            FrmEmprestimos telaEmprestimos = new FrmEmprestimos();
                telaEmprestimos.Show();
            
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
