using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SchoolCommunity.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.ViewComponents
{
    public class FormCadastrarAlunoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(AlunoVM Aluno, string Fluxo)
        {
            AlunoVM viewModel = new AlunoVM();

            //viewModel.ListarEstadosDropDownList();
            //viewModel.ListarCidadesDropDownList("TO");

            if (Fluxo == "0")
            {
                viewModel.PopulaModelAluno(Aluno);
            }
            else
            {
                
            }
            
            //if (Fluxo == "0")
            //{
                //viewModel.CarregarAlunos();
                //viewModel.CadastrarAluno(Aluno);
            //}
            
            return View("FormCadastrarAluno");
        }

    }
}