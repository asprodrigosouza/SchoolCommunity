using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.DataBase
{
    public class MongoDBDataBase
    {
        
        public IMongoDatabase GetConnect()
        {
            // Conectar no Servidor
            Console.WriteLine("Conectando no Servidor...");
            var client = new MongoClient("mongodb://localhost:27017");
            
            // Conectar no Banco de Dados
            Console.WriteLine("Conectando no Bando de Dados...");
            var dataBaseConn = client.GetDatabase("SchoolCommunityDB");

            // Retorna Conexão Banco
            return dataBaseConn;
        }
        
    }
}
