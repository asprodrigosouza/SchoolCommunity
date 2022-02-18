using MongoDB.Driver;
using SchoolCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.MongoDAO
{
    public class EventoDAO
    {
        // MÉTODO RESPONSÁVEL POR FINALIZAR O FLUXO DE SALVAMENTO DO EVENTO NO BANCO (MONGODB)
        public void CriarEvento(IMongoCollection<Evento> eventoColecao, Evento infoEvento)
        {
            Console.WriteLine("Cadastrando Evento...");
            eventoColecao.InsertOne(infoEvento);
            Console.WriteLine("Evento Cadastrado!");
        }

        public void LerEventos()
        {

        }

    }
}
