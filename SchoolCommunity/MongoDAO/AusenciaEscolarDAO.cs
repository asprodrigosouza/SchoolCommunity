using MongoDB.Driver;
using SchoolCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.MongoDAO
{
    public class AusenciaEscolarDAO
    {

        public void CadastrarAusenciaEscolar(IMongoCollection<AusenciaEscolar> ausenciaEscolarColecao, AusenciaEscolar infoAusencia)
        {
            Console.WriteLine("Cadastrando Ausencia Escolar...");
            ausenciaEscolarColecao.InsertOne(infoAusencia);
            Console.WriteLine("Ausencia Escolar Cadastrado com Sucesso!");
        }

    }
}
