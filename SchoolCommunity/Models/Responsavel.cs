using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models
{
    public class Responsavel : Usuario
    {
        // public List<Aluno> Dependente { get; set; }
        public string RG_Documento { get; set; }
        public string Profissao { get; set; }
    }
}
