using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDbiblioteca
{
    public class validacaoLivro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string AnoPubica { get; set; }
        public string QtdDisp { get; set; }
        public string QtdTotal { get; set; }

        public string ValidarLivro()
        {
            if (string.IsNullOrWhiteSpace(this.Titulo))
            {
                return "O título do livro não pode estar vazio.";
            }

            if (string.IsNullOrWhiteSpace(this.Autor))
            {
                return "O autor é necessário!";
            }

            if (string.IsNullOrWhiteSpace(this.QtdDisp))
            {
                return "Precisamos saber a quantidade disponivel para controlar o estoque!";
            }

            if (string.IsNullOrWhiteSpace(this.QtdTotal))
            {
                return "Precisamos saber a quantidade total para controlar o estoque!.";
            }



            return null;
        }
    }
}