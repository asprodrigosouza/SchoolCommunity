using MongoDB.Driver;
using SchoolCommunity.DataBase;
using SchoolCommunity.MongoDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models.ViewModels
{
    public class EventoVM
    {
        public string NomeEvento { get; set; }
        public string LocalEvento { get; set; }
        public string DataInicialEvento { get; set; }
        public string DataFinalEvento { get; set; }
        public string DescricaoObservacaoEvento { get; set; }

        public List<Evento> EventosAgendados { get; set; }

        public void PopulaModelEvento(EventoVM InfoEventoEscolar)
        {
            Evento evento = new Evento();

            // =====>>> DADOS DO EVENTO <<<====== //

            // - Descrições do Evento
            evento.Nome = InfoEventoEscolar.NomeEvento;
            evento.Local = InfoEventoEscolar.LocalEvento;
            evento.DescricaoObservacao = InfoEventoEscolar.DescricaoObservacaoEvento;

            // - Cronograma do Evento 
            evento.DataInicio = InfoEventoEscolar.DataInicialEvento;
            evento.DataFim = InfoEventoEscolar.DataFinalEvento;

            AgendarEvento(evento);
        }
        
        public void AgendarEvento(Evento eventoInfo)
        {
            Console.WriteLine("Obtendo Coleção('Tabela') de Eventos...");
            IMongoCollection<Evento> evento = MongoDBDataBase.GetConnect.GetCollection<Evento>("Eventos");

            EventoDAO eventoDAO = new EventoDAO();

            eventoDAO.CriarEvento(evento, eventoInfo);
        }

        public List<Evento> ListarEventosAgendados()
        {
            // Filtro
            var filtro = Builders<Evento>.Filter.Empty;

            IMongoCollection<Evento> eventosAgendados = MongoDBDataBase.GetConnect.GetCollection<Evento>("Eventos");
            EventosAgendados = eventosAgendados.Find<Evento>(filtro).ToList();

            return EventosAgendados;
        }

    }
}
