using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SchoolCommunity.Models;
using SchoolCommunity.Models.ViewModels;
using SchoolCommunity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.ViewComponents
{
    public class ForumViewComponent : ViewComponent
    {
        DataBaseServiceJSON _dataBaseServiceJSON;

        public ForumViewComponent()
        {
            _dataBaseServiceJSON = new DataBaseServiceJSON();
        }

        public IViewComponentResult Invoke(ForumVM Pergunta, string Fluxo, IMongoDatabase pocDataBaseMongoConn)
        {
            ForumVM viewModel = new ForumVM();

            // Busca da base todos as Perguntas Postadas
            //List<Forum> lista = _dataBaseServiceJSON.DeserializarNewtonsoft<Forum>("Forum.json", string.Concat(Environment.CurrentDirectory, @"\DataBaseSchoolCommunity\"));

            //viewModel.CarregarPerguntas();
            //viewModel.TopicosRecentes();
            //viewModel.PerguntasSemRespostas();

            // Realizar Pergunta
            if (Fluxo == "0")
            {
                //viewModel.PostarPergunta(Pergunta);
                //viewModel.TopicosRecentes();
                viewModel.PopularModelPergunta(Pergunta, pocDataBaseMongoConn);
            }
            
            return View("Forum", viewModel);
        }
    }
}
