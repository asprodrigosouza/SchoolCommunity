using MongoDB.Driver;
using SchoolCommunity.DataBase;
using SchoolCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.MongoDAO
{
    public class AlunoDAO
    {
        //MongoDBDataBase mongoDBDataBase = new MongoDBDataBase(); 

        //public IMongoDatabase retornaConexaoBanco()
        //{
        //    var conexao = mongoDBDataBase.GetConnect();
        //    return conexao;
        //}


        public void CadastrarAluno(IMongoCollection<Aluno> alunoColecao, Aluno infoAluno)
        {
            Console.WriteLine("Cadastrando Aluno...");
            alunoColecao.InsertOne(infoAluno);
            Console.WriteLine("Aluno Cadastrado!");
        }
        
    }
}
