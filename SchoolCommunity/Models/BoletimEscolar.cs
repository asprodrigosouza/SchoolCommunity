using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models
{
    public class BoletimEscolar
    {
        public List<Materias> ListaDeMateriasBoletim { get; set; }
        public List<Notas> ListaDeNotasBoletim { get; set; }
        public Aluno Aluno { get; set; }
    }
}
