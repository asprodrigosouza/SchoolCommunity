using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models
{
    public class Turma
    {
        //public int IdTurma { get; set; }
        public ObjectId _id { get; set; }
        public string DescricaoTurma { get; set; }
        public string PeriodoTurma { get; set; }
        public string AnoLetivoTurma { get; set; }
        //public string CursoAno { get; set; }
        
    }
}
