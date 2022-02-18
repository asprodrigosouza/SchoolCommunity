using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models
{
    public class Professor : Usuario
    {
        public List<Materias> MateriasMinistradas { get; set; }
        public string FormacaoAcademica { get; set; }
    }
}
