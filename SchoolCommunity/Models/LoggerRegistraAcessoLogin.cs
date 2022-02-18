using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models
{
    public class LoggerRegistraAcessoLogin
    {

        public ObjectId _id { get; set; }
        public ObjectId IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string DataDeAcesso { get; set; }
        public string HoraDeAcessoLogin { get; set; }

    }
}
