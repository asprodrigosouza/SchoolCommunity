using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models
{
    public class Aluno : Usuario
    {
        public Aluno()
        {
            CursoAno = new CursoAno();
            Turma = new Turma();
            Responsavel = new Responsavel();
        }

        public CursoAno CursoAno { get; set; }
        public Turma Turma { get; set; }
        public Responsavel Responsavel { get; set; }

        // public DateTime AnoLetivo { get; set; }
    }
}
