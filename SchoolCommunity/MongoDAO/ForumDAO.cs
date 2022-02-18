using MongoDB.Driver;
using SchoolCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.MongoDAO
{
    public class ForumDAO
    {

        public void PostarPergunta(IMongoCollection<Forum> forumColecao, Forum infoPergunta)
        {
            Console.WriteLine("Postando Pergunta...");
            forumColecao.InsertOne(infoPergunta);
            Console.WriteLine("Pergunta Postada!");
        }

    }
}
