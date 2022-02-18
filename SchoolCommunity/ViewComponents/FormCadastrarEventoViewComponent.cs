using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SchoolCommunity.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.ViewComponents
{
    public class FormCadastrarEventoViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(EventoVM evento, string fluxo)
        {
            EventoVM viewModel = new EventoVM();

            // FLUXO = 0 -> CRIAR NOVO EVENTO
            if (fluxo == "0")
                viewModel.PopulaModelEvento(evento);

            // FLUXO = 1 -> ATUALIZAR EVENTO 
            else
            {
             
            }

            return View("FormCadastrarEvento");
        }

    }
}
