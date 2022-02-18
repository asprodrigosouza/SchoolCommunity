using MongoDB.Bson;
using MongoDB.Driver;
using SchoolCommunity.DataBase;
using SchoolCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.MongoDAO
{
    public class UsuarioDAO
    {
        public bool FiltrarUsuarioPorId(ObjectId idUsuario)
        {
            Console.WriteLine("Obtendo Coleção LoggerRegistraAcessoLogin ... UsuarioDAO -> FiltrarUsuarioPorId()");
            IMongoCollection<LoggerRegistraAcessoLogin> colecaoLoggerAcessoLogin = MongoDBDataBase.GetConnect.GetCollection<LoggerRegistraAcessoLogin>("LoggerRegistraAcessoLogin");
            
            var filtro = Builders<LoggerRegistraAcessoLogin>.Filter.Eq(x => x.IdUsuario, idUsuario);
            var result = colecaoLoggerAcessoLogin.Find<LoggerRegistraAcessoLogin>(filtro);

            //return result;

            if (result.CountDocuments() > 0)
                return false;
            else
                return true;
        }

    }
}
