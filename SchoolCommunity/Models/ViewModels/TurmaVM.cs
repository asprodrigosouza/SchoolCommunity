using MongoDB.Bson;
using MongoDB.Driver;
using SchoolCommunity.DataBase;
using SchoolCommunity.MongoDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models.ViewModels
{
    public class TurmaVM
    {
        public TurmaVM()
        {
            ExibirModal = true;
        }

        public List<Turma> _listaDeTurmasCadastradas { get; set; }

        // DADOS
        public ObjectId _id { get; set; }
        public string Descricao { get; set; }
        public string Periodo { get; set; }
        public string AnoLetivo { get; set; }


        // FLUXOS - CADASTRAR TURMA | EDITAR TURMA
        public int Fluxo { get; set; }
        public bool ExibirModal { get; set; }

        public void PopulaModelTurma(TurmaVM InfoTurma)
        {
            Turma turma = new Turma();
            turma.DescricaoTurma = InfoTurma.Descricao;
            turma.PeriodoTurma = InfoTurma.Periodo;
            turma.AnoLetivoTurma = InfoTurma.AnoLetivo;


            CadastrarTurma(turma);
        }

        public void CadastrarTurma(Turma turmaInfo)
        {
            try
            {
                Console.WriteLine("Obtendo Coleção(Tabela) de Turmas...");
                IMongoCollection<Turma> turmas = MongoDBDataBase.GetConnect.GetCollection<Turma>("Turmas");

                TurmaDAO turmaDAO = new TurmaDAO();

                turmaDAO.CadastrarTurma(turmas, turmaInfo);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void EditarAtualizarTurma(ObjectId idTurma, TurmaVM turmaInfo)
        {
            try
            {
                Console.WriteLine("Obtendo Coleção(Tabela) de Turmas... Método Editar Atualizar Turma");
                IMongoCollection<Turma> collection = MongoDBDataBase.GetConnect.GetCollection<Turma>("Turmas");

                var filtro = Builders<Turma>.Filter.Eq(x => x._id, idTurma);
                var result = collection.Find<Turma>(filtro);
                
                if (result.CountDocuments() > 0)
                {
                    var turma = result.FirstOrDefault();

                    // Popula Model Atualizado

                    turma.DescricaoTurma = turmaInfo.Descricao;
                    turma.PeriodoTurma = turmaInfo.Periodo;
                    turma.AnoLetivoTurma = turmaInfo.AnoLetivo;

                    TurmaDAO turmaDAO = new TurmaDAO();

                    turmaDAO.AtualizarTurma(collection, turma);
                }
                
            }catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void CarregaTurmasCadastradas()
        {
            Console.WriteLine("Obtendo Coleção(Tabela) de Turmas... Método Carrega Turmas Cadastradas");
            IMongoCollection<Turma> colecaoTurmas = MongoDBDataBase.GetConnect.GetCollection<Turma>("Turmas");

            var filtro = Builders<Turma>.Filter.Empty;
            var turmas = colecaoTurmas.Find<Turma>(filtro).ToList();

            _listaDeTurmasCadastradas = turmas;
        }

        public void CarregaTurma(ObjectId idTurma)
        {
            Console.WriteLine("Carregando Turma... Método Carrega Turma");
            IMongoCollection<Turma> colecaoTurmas = MongoDBDataBase.GetConnect.GetCollection<Turma>("Turmas");

            var filtro = Builders<Turma>.Filter.Eq(x => x._id, idTurma);
            var result = colecaoTurmas.Find<Turma>(filtro);

            if (result.CountDocuments() > 0)
            {
                var turma = result.FirstOrDefault();

                _id = turma._id;
                Descricao = turma.DescricaoTurma;
                Periodo = turma.PeriodoTurma;
                AnoLetivo = turma.AnoLetivoTurma;
            }
        }
    }
}
