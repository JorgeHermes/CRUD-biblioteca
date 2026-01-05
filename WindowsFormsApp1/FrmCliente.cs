using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDbiblioteca.enums;

namespace CRUDbiblioteca
{
    public partial class FrmCliente : Form
    {
        private OpcaoCliente acaoAtual = OpcaoCliente.Nenhuma;
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void excluir_Click(object sender, EventArgs e)
        {
            acaoAtual = OpcaoCliente.Excluir;
        }

        private void cadastrar_Click(object sender, EventArgs e)
        {
            acaoAtual = OpcaoCliente.Cadastrar;
        }

        private void atualizar_Click(object sender, EventArgs e)
        {
            acaoAtual = OpcaoCliente.Atualizar;
        }


    }
}
