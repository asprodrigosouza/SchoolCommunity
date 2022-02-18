using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models
{
    public class UsuarioLogin
    {

        public string _id { get; set; }
        public string NomeUsuario { get; set; }
        public string LoginUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public string PerfilUsuario { get; set; }
        public bool StatusUsuario { get; set; }

    }
}
