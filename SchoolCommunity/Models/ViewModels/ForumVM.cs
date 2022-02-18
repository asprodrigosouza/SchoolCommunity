using MongoDB.Driver;
using SchoolCommunity.MongoDAO;
using SchoolCommunity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models.ViewModels
{
    public class ForumVM
    {
        // Serviço do Banco de Dados JSON (Banco não Relacional)
        DataBaseServiceJSON _dataBaseServiceJSON;

        // Lista de Perguntas
        List<Forum> _listaPerguntas = new List<Forum>();

        // Recebe Lista de Perguntas Recentes (Tópicos Recentes)
        public List<Forum> _listaPerguntasRecentes;

        // Recebe Lista de Perguntas sem Respostas
        public List<Forum> _listaPerguntasSemRespostas;

        // Dados da Pergunta
        public Forum DadosDaPergunta { get; set; }

        // Autor Usuário Pergunta Forúm
        public string AutorUsuarioPerguntaForum { get; set; }

        // Título Pergunta
        public string TituloPerguntaForum { get; set; }

        // Descrição Pergunta
        public string DescricaoPerguntaForum { get; set; }

        // Tags Pergunta
        public string TagsPerguntaForum { get; set; }

        // Data Realização Pergunta
        public string DataHoraRealizacaoPerguntaForum { get; set; }

        public ForumVM()
        {
            _dataBaseServiceJSON = new DataBaseServiceJSON();
            _listaPerguntasRecentes = new List<Forum>();
        }

        public void PostarPergunta(ForumVM InfoPergunta)
        {
            Forum pergunta = new Forum();

            if (_listaPerguntas == null || _listaPerguntas.Count == 0)
            {
                _listaPerguntas = new List<Forum>();
                pergunta.Pergunta.IdPergunta = Guid.NewGuid().ToString();
            }
            else
            {
                //aluno.Id = _listaAlunos.Max(x => x.Id);
                //aluno.Id++;
                pergunta.Pergunta.IdPergunta = Guid.NewGuid().ToString();
            }

            // Dados Pergunta
            pergunta.Pergunta.AutorUsuarioPergunta = InfoPergunta.AutorUsuarioPerguntaForum;
            pergunta.Pergunta.TituloPergunta = InfoPergunta.TituloPerguntaForum;
            pergunta.Pergunta.DescricaoPergunta = InfoPergunta.DescricaoPerguntaForum;
            pergunta.Pergunta.TagsPergunta = InfoPergunta.TagsPerguntaForum;
            pergunta.Pergunta.DataHoraRealizacaoPergunta = InfoPergunta.DataHoraRealizacaoPerguntaForum;

            _listaPerguntas.Add(pergunta);

            _dataBaseServiceJSON.SerializarNewtonsoft<Forum>(_listaPerguntas, "Forum.json", string.Concat(Environment.CurrentDirectory, @"\DataBaseSchoolCommunity\"));
        }

        public void PopularModelPergunta(ForumVM InfoPergunta, IMongoDatabase mongoDatabase)
        {
            Forum pergunta = new Forum();

            // ID DA PERGUNTA
            pergunta.Pergunta.IdPergunta = Guid.NewGuid().ToString();

            // DADOS DA PERGUNTA
            pergunta.Pergunta.AutorUsuarioPergunta = InfoPergunta.AutorUsuarioPerguntaForum;
            pergunta.Pergunta.TituloPergunta = InfoPergunta.TituloPerguntaForum;
            pergunta.Pergunta.DescricaoPergunta = InfoPergunta.DescricaoPerguntaForum;
            pergunta.Pergunta.TagsPergunta = InfoPergunta.TagsPerguntaForum;
            pergunta.Pergunta.DataHoraRealizacaoPergunta = InfoPergunta.DataHoraRealizacaoPerguntaForum;

            PocMongoPostarPergunta(mongoDatabase, pergunta);
        }

        public void PocMongoPostarPergunta(IMongoDatabase dataBase, Forum perguntaInfo)
        {
            Console.WriteLine("Obtendo Coleção(Tabela) Forum...");
            IMongoCollection<Forum> pergunta = dataBase.GetCollection<Forum>("Forum");

            ForumDAO forumDAO = new ForumDAO();

            forumDAO.PostarPergunta(pergunta, perguntaInfo);
        }

        public void CarregarPerguntas()
        {
            // Teste Console
            //var caminhoTesteConsole = @"C:\Users\jivis\Documents\SOW Connect\ESTUDOS\UNASP\PROI1 - PROJETO INTEGRADOR I\SchoolCommunity\SchoolCommunity";
            //_listaPerguntas = _dataBaseServiceJSON.DeserializarNewtonsoft<Forum>("Forum.json", string.Concat(caminhoTesteConsole, @"\DataBaseSchoolCommunity\"));

            // Busca da base todos as Perguntas Postadas
            _listaPerguntas = _dataBaseServiceJSON.DeserializarNewtonsoft<Forum>("Forum.json", string.Concat(Environment.CurrentDirectory, @"\DataBaseSchoolCommunity\"));
        }

        // Popula lista de perguntas recentes (Tópicso Recentes)
        public void TopicosRecentes()
        {
            _listaPerguntasRecentes = _listaPerguntas
                .FindAll(x => x.Pergunta.DataHoraRealizacaoPergunta.Contains(DateTime.Today.ToString("dd/MM/yyyy")))
                .OrderBy(x => x.Pergunta.DataHoraRealizacaoPergunta)
                .ToList();
        }

        // Popula lista de perguntas sem respostas
        public void PerguntasSemRespostas()
        {
            _listaPerguntasSemRespostas = _listaPerguntas
                .FindAll(x => x.Resposta.DescricaoResposta == null)
                .OrderBy(x => x.Pergunta.DataHoraRealizacaoPergunta)
                .ToList();
        }

        // Modal Pergunta
        public Forum PerguntaForum(Forum pergunta)
        {
            DadosDaPergunta = pergunta;
            return DadosDaPergunta;
        }
            
        // Criar Resposta
        public void CriarRespotaForum(Forum pergunta, string resposta)
        {
            pergunta.Resposta.DescricaoResposta = resposta;

            SalvarRespostaBaseJSON(pergunta);
        }

        // POSTAR RESPOSTA
        public void PocMongoPostarResposta(IMongoCollection<Forum> mongoColecaoForum, string idPergunta, string descricaoResposta)
        {
            Console.WriteLine("Criando Resposta...");

            // FILTRO
            var filtrarPergunta = Builders<Forum>.Filter.Where(x => x.Pergunta.IdPergunta == "326d381b-ff3f-4135-8ef6-f11445e156f7");

            // ALTERAÇÃO
            var addResposta = Builders<Forum>.Update.Set(p => p.Resposta.DescricaoResposta, "Teste_Resposta_Professor");

            mongoColecaoForum.UpdateMany(filtrarPergunta, addResposta);
        }

        private void SalvarRespostaBaseJSON(Forum resposta)
        {
            string json = System.IO.File.ReadAllText("Forum.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            jsonObj["Bots"][0]["Password"] = "new password";
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText("Forum.json", output);

            //CarregarPerguntas();
            //_listaPerguntas.Add(resposta);
            //_dataBaseServiceJSON.SerializarNewtonsoft<Forum>(_listaPerguntas, "Forum.json", string.Concat(Environment.CurrentDirectory, @"\DataBaseSchoolCommunity\"));
        }
    }
}