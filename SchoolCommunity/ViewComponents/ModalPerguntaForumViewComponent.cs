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
    public class ModalPerguntaForumViewComponent : ViewComponent
    {
        DataBaseServiceJSON _dataBaseServiceJSON;

        public ModalPerguntaForumViewComponent()
        {
            _dataBaseServiceJSON = new DataBaseServiceJSON();
        }

        public IViewComponentResult Invoke(string idPergunta, string descResposta, string fluxo, IMongoDatabase pocDataBaseMongoConn)
        {
            var viewModel = new ForumVM();

            //Busca da base todos as Perguntas Postadas
            List<Forum> lista = _dataBaseServiceJSON.DeserializarNewtonsoft<Forum>("Forum.json", string.Concat(Environment.CurrentDirectory, @"\DataBaseSchoolCommunity\"));

            Forum pergunta = lista.Where(x => x.Pergunta.IdPergunta == idPergunta).FirstOrDefault();

            if (fluxo == "0")
                viewModel.PerguntaForum(pergunta);
            else
                viewModel.CriarRespotaForum(pergunta, descResposta);


            return View("ModalPerguntaForum", viewModel);
        }

    }
}
