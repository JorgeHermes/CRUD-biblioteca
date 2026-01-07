using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDbiblioteca
{
    public class validacaoCliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string TipoCliente { get; set; }

        public string Validar()
        {
            if (string.IsNullOrWhiteSpace(this.Nome))
            {
                return "O nome do cliente não pode estar vazio.";
            }

            if (string.IsNullOrWhiteSpace(this.Telefone))
            {
                return "O telefone é necessário para entrarmos em contato com vc!";
            }

            if (string.IsNullOrWhiteSpace(this.CPF))
            {
                return "É necessário o CPF para seu cadastro!";
            }

            if (string.IsNullOrWhiteSpace(this.TipoCliente))
            {
                return "É importante para nós sabermos que tipo de cliente vc é!";
            }

            if (!string.IsNullOrEmpty(this.Email) && !this.Email.Contains("@"))
            {
                return "O formato do e-mail é inválido.";
            }

            return null;
        }
    }
}