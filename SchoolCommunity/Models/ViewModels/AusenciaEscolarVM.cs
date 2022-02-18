using MongoDB.Driver;
using SchoolCommunity.MongoDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models.ViewModels
{
    public class AusenciaEscolarVM
    {

        public string NomeAluno { get; set; }
        public string MotivoAusencia { get; set; }
        public string ConfirmaFalta { get; set; }


        public void PopulaModelAusenciaEscolar(AusenciaEscolarVM infoAusencia, IMongoDatabase conexao)
        {
            AusenciaEscolar ausencia = new AusenciaEscolar();

            ausencia.NomeAluno = infoAusencia.NomeAluno;
            ausencia.MotivoAusencia = infoAusencia.MotivoAusencia;
            ausencia.ConfirmaFalta = infoAusencia.ConfirmaFalta;
         
            CadastrarAusenciaEscolar(conexao, ausencia);
        }

        public void CadastrarAusenciaEscolar(IMongoDatabase dataBase, AusenciaEscolar infoAusencia)
        {
            Console.WriteLine("Obtendo Coleção(Tabela) de Ausencia...");
            IMongoCollection<AusenciaEscolar> ausencia = dataBase.GetCollection<AusenciaEscolar>("AusenciaEscolar");

            AusenciaEscolarDAO ausenciaDAO = new AusenciaEscolarDAO();

            ausenciaDAO.CadastrarAusenciaEscolar(ausencia, infoAusencia);
        }


    }
}
