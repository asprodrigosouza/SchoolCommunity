using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models
{
    public class Respostas
    {
        public int IdResposta { get; set; }
        public Perguntas Pergunta { get; set; }
        public string DescricaoResposta { get; set; }
    }
}
