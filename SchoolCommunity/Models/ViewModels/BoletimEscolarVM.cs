using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models.ViewModels
{
    public class BoletimEscolarVM
    {
        public List<Materias> Materias { get; set; }
        public List<Notas> Notas { get; set; }

        public BoletimEscolarVM()
        {
            InicializaBoletimEscolar();
        }

        private void InicializaBoletimEscolar()
        {
            Materias = new List<Materias>
            {
                new Materias { NomeMateria = "Língua Portuguesa" },
                new Materias { NomeMateria = "Arte" },
                new Materias { NomeMateria = "Educação Física" },
                new Materias { NomeMateria = "Matemática" },
                new Materias { NomeMateria = "Ciências" },
                new Materias { NomeMateria = "História" },
                new Materias { NomeMateria = "Geografia" },
                new Materias { NomeMateria = "Ensino Religioso" },
                new Materias { NomeMateria = "Língua Estr.(Inglês)" }
            };    
        }
    }
}
