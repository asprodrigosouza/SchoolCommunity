using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.DataBase
{
    public sealed class MongoDBDataBase
    {
        private static volatile MongoDBDataBase instace;
        private static object syncLock = new Object();
        private static IMongoDatabase db = null;

        private MongoDBDataBase()
        {
            Console.WriteLine("Conectando no Servidor...");
            var client = new MongoClient("mongodb://localhost:27017");

            Console.WriteLine("Conectando no Bando de Dados...");
            db = client.GetDatabase("SchoolCommunityDB");
        }


        public static IMongoDatabase GetConnect
        {
            get 
            {
                if (instace == null)
                {
                    lock (syncLock)
                    {
                        if (instace == null)
                        {
                            instace = new MongoDBDataBase();
                            Console.WriteLine("\n\n\n:: Nova Conexão - Instância Criada");
                            
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\n\n\n:: Reutilizando Conexão");
                }

                return db;
            }
        }
        
    }
}
