using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SchoolCommunity.DataBase;
using SchoolCommunity.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.ViewComponents
{
    public class TurmasCadastradasViewComponent : ViewComponent 
    {
        public IViewComponentResult Invoke()
        {
            TurmaVM viewModel = new TurmaVM();

            viewModel.CarregaTurmasCadastradas();

            return View("TurmasCadastradas", viewModel);
        }

    }
}
