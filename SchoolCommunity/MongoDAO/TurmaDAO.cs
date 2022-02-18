using MongoDB.Driver;
using SchoolCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.MongoDAO
{
    public class TurmaDAO
    {

        public void CadastrarTurma(IMongoCollection<Turma> alunoColecao, Turma infoTurma)
        {
            Console.WriteLine("Cadastrando Turma...");
            alunoColecao.InsertOne(infoTurma);
            Console.WriteLine("Turma Cadastrada!");
        }

        public void AtualizarTurma(IMongoCollection<Turma> turmaColecao, Turma infoTurmaAtualizada)
        {
            Console.WriteLine("Atualizando Turma...");
            var filtro = Builders<Turma>.Filter.Eq(x => x._id, infoTurmaAtualizada._id);
            var update = Builders<Turma>.Update.Set("Turmas", infoTurmaAtualizada);

            turmaColecao.UpdateOne(filtro, update);
        }

    }
}
