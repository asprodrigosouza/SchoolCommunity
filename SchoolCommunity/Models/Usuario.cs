using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models
{
    public abstract class Usuario
    {
        public string Id { get; set; } // GUID // public int Id { get; set; }
        public string Nome { get; set; }
        // public string Endereco { get; set; }

        // Endereço
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        
        // Dados de Contato
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Email { get; set; }

        public string FatorRH { get; set; }
        public string DataNascimento { get; set; } // public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Alergias { get; set; }
    }
}