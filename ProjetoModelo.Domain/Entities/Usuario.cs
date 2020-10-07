using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoModelo.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public bool Autorizado { get; set; }

        public string Token { get; set; }
    }
}
