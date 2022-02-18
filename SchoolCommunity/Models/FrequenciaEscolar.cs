using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models
{
    public class FrequenciaEscolar
    {
        public Aluno Aluno { get; set; }
        public int IdMateria { get; set; }
        public int QuantidadeFaltas { get; set; }
        
    }
}
