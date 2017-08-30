using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrabalhandoComWord
{
    class Cliente
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public string Telefone { get; set; }

        public Cliente(string nome, string sobrenome, string telefone)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Telefone = telefone;
        }
    }
}
