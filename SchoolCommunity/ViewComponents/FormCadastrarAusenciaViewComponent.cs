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
    public class FormCadastrarAusenciaViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(AusenciaEscolarVM Ausencia, string Fluxo)
        {
            AusenciaEscolarVM ausenciaEscolarVM = new AusenciaEscolarVM();

            // FLUXO = 0 | CADASTRAR AUSENCIA ESCOLAR
            if (Fluxo == "0")
            {
                ausenciaEscolarVM.PopulaModelAusenciaEscolar(Ausencia, MongoDBDataBase.GetConnect);
            }
            else 
            {

            }

            return View("FormCadastrarAusencia");
        }
    }
}
