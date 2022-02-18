using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models
{
    public class Perguntas
    {
        public string IdPergunta { get; set; } //public int IdPergunta { get; set; }
        public string AutorUsuarioPergunta { get; set; }
        public string TituloPergunta { get; set; }
        public string DescricaoPergunta { get; set; }
        public string TagsPergunta { get; set; }
        public string DataHoraRealizacaoPergunta { get; set; }
    }
}
