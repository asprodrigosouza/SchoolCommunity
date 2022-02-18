using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models
{
    public class Evento
    {
        public ObjectId _id { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public string DescricaoObservacao { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        
        //public double Valor { get; set; }
        //public bool Autorizacao { get; set; }
    }
}
