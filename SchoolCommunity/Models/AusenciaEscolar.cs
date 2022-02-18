using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models
{
    public class AusenciaEscolar
    {
        public ObjectId _id { get; set; }
        public string NomeAluno { get; set; }
        public string MotivoAusencia { get; set; }
        public string ConfirmaFalta { get; set; }


    }
}
