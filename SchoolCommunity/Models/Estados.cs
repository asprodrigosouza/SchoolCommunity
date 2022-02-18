using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models
{
    public class Estados
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public List<string> Cidades { get; set; }
    }
}
