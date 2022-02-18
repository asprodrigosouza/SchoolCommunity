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
    public class ModalFormCadastrarTurmaViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(TurmaVM Turma, int fluxo, string idTurma)
        {
            TurmaVM viewModel = new TurmaVM();
            viewModel.Fluxo = fluxo;
            
            // FLUXO 1 -> Cadastrar
            if (viewModel.Fluxo == 1)
            {
                viewModel.PopulaModelTurma(Turma);
            }

            // FLUXO 2 -> Popula dados para Edição
            else if (viewModel.Fluxo == 2)
            {
                viewModel.CarregaTurma(MongoDB.Bson.ObjectId.Parse(idTurma));
            }

            // FLUXO 3 -> Salvar Alterações da Edição
            else if (viewModel.Fluxo == 3)
            {
                viewModel.EditarAtualizarTurma(Turma._id,Turma);
            }

            
            return View("ModalFormCadastrarTurma", viewModel);
        }

    }
}
