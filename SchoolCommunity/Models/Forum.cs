using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models
{
    public class Forum
    {
        public Forum()
        {
            Pergunta = new Perguntas();
            Resposta = new Respostas();
        }
        
        public Perguntas Pergunta { get; set; } // public List<Perguntas> Perguntas { get; set; }
        public Respostas Resposta { get; set; } // public List<Respostas> Respostas { get; set; }
    }
}
