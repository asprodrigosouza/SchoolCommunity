using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models.ViewModels
{
    public class CadastrarEventoVM
    {
        public string NomeEvento { get; set; }
        public string LocalEvento { get; set; }
        public string DataHoraInicialEvento { get; set; }
        public string DataHoraFinalEvento { get; set; }
    }
}
