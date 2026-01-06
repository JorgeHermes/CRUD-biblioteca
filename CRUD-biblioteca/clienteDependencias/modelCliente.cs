using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDbiblioteca
{
    public class modelCliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public string Validar()
        {
            if (string.IsNullOrWhiteSpace(this.Nome))
            {
                return "O nome do cliente não pode estar vazio.";
            }

            if (string.IsNullOrWhiteSpace(this.Telefone))
            {
                return "O telefone é necessário para entrarmos em contato com vc :)";
            }

            if (!string.IsNullOrEmpty(this.Email) && !this.Email.Contains("@"))
            {
                return "O formato do e-mail é inválido.";
            }

            return null;
        }
    }
}