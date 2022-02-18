using MongoDB.Driver;
using SchoolCommunity.DataBase;
using SchoolCommunity.MongoDAO;
using SchoolCommunity.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Models.ViewModels
{
    public class AlunoVM
    {
        public AlunoVM()
        {
            _dataBaseServiceJSON = new DataBaseServiceJSON();    
        }

        // Serviço do Banco de Dados JSON (Banco não Relacional)
        DataBaseServiceJSON _dataBaseServiceJSON;

        // Lista de Alunos
        List<Aluno> _listaAlunos { get; set; }
        List<Estados> _listaUF_Cidades { get; set; }

        // Dados Básicos
        public string NomeAluno { get; set; }
        public string DataNascimentoAluno { get; set; }
        public string Sexo { get; set; }
        public string FatorRH { get; set; }

        // Dados Escolares
        public string CursoAluno { get; set; }
        public string TurmaAluno { get; set; }
        public string PeriodoEscolarAluno { get; set; }
        public string AnoLetivoAluno { get; set; }
        public string SituacaoMatricula { get; set; }

        // Dados Complementares
        public string AlergiasAluno { get; set; }

        // Dados de Endereço
        public string EstadoDoAluno { get; set; }
        public string CidadeDoAluno { get; set; }
        public string LogradouroDoAluno { get; set; }
        public string BairroDoAluno { get; set; }
        public string NumeroDoAluno { get; set; }

        // Dados do Responsável do Aluno
        public string NomeResponsavelDoAluno { get; set; }
        public string DataNascimentoResponsavelDoAluno { get; set; }
        public string RG_DocumentoReponsavelDoAluno { get; set; }
        public string ProfissaoResponsavelDoAluno { get; set; }

        // Dados de Contato dos Responsável do Aluno
        public string EmailResponsavelDoAluno { get; set; }
        public string Tel1ResponsavelDoAluno { get; set; }
        public string Tel2ResponsavelDoAluno { get; set; }

        // Fluxo
        // public string Fluxo { get; set; }

        public void CadastrarAluno(AlunoVM InfoAluno)
        {
            Aluno aluno = new Aluno();

            if (_listaAlunos == null || _listaAlunos.Count == 0)
            {
                _listaAlunos = new List<Aluno>();
                aluno.Id = Guid.NewGuid().ToString();
                aluno.Responsavel.Id = Guid.NewGuid().ToString();
            }
            else
            {
                //aluno.Id = _listaAlunos.Max(x => x.Id);
                //aluno.Id++;

                aluno.Id = Guid.NewGuid().ToString();
                aluno.Responsavel.Id = Guid.NewGuid().ToString();
            }
            
            // Dados Básicos
            aluno.Nome = InfoAluno.NomeAluno;
            aluno.DataNascimento = InfoAluno.DataNascimentoAluno;
            aluno.Sexo = InfoAluno.Sexo;
            aluno.FatorRH = InfoAluno.FatorRH;

            // Dados Escolares
            aluno.CursoAno.DescricaoCursoAno = InfoAluno.CursoAluno;
            aluno.CursoAno.AnoLetivo = InfoAluno.AnoLetivoAluno;
            aluno.Turma.DescricaoTurma = InfoAluno.TurmaAluno;
            aluno.Turma.PeriodoTurma = InfoAluno.PeriodoEscolarAluno;

            // Dados Complementares
            aluno.Alergias = InfoAluno.AlergiasAluno;

            // Dados de Endereço
            aluno.Estado = InfoAluno.EstadoDoAluno;
            aluno.Cidade = InfoAluno.CidadeDoAluno;
            aluno.Logradouro = InfoAluno.LogradouroDoAluno;
            aluno.Bairro = InfoAluno.BairroDoAluno;
            aluno.Numero = InfoAluno.NumeroDoAluno;

            // Dados do Responsável do Aluno
            aluno.Responsavel.Nome = InfoAluno.NomeResponsavelDoAluno;
            aluno.Responsavel.RG_Documento = InfoAluno.RG_DocumentoReponsavelDoAluno;
            aluno.Responsavel.Profissao = InfoAluno.ProfissaoResponsavelDoAluno;
            aluno.Responsavel.DataNascimento = InfoAluno.DataNascimentoResponsavelDoAluno;
            
            // Dados de Contato dos Responsável do Aluno
            aluno.Responsavel.Email = InfoAluno.EmailResponsavelDoAluno;
            aluno.Responsavel.Tel1 = InfoAluno.Tel1ResponsavelDoAluno;
            aluno.Responsavel.Tel2 = InfoAluno.Tel2ResponsavelDoAluno;

            _listaAlunos.Add(aluno);

            _dataBaseServiceJSON.SerializarNewtonsoft<Aluno>(_listaAlunos, "Usuarios.json", string.Concat(Environment.CurrentDirectory, @"\DataBaseSchoolCommunity\"));
        }

        public void PopulaModelAluno(AlunoVM InfoAluno)
        {
            Aluno aluno = new Aluno();

            // ID DO ALUNO
            aluno.Id = Guid.NewGuid().ToString();

            // DADOS BÁSICOS
            aluno.Nome = InfoAluno.NomeAluno;
            aluno.DataNascimento = InfoAluno.DataNascimentoAluno;
            aluno.Sexo = InfoAluno.Sexo;
            aluno.FatorRH = InfoAluno.FatorRH;

            // DADOS ESCOLARES
            aluno.CursoAno.DescricaoCursoAno = InfoAluno.CursoAluno;
            aluno.CursoAno.AnoLetivo = InfoAluno.AnoLetivoAluno;
            aluno.Turma.DescricaoTurma = InfoAluno.TurmaAluno;
            aluno.Turma.PeriodoTurma = InfoAluno.PeriodoEscolarAluno;

            // DADOS COMPLEMENTARES
            aluno.Alergias = InfoAluno.AlergiasAluno;

            // DADOS DE ENDEREÇO
            aluno.Estado = InfoAluno.EstadoDoAluno;
            aluno.Cidade = InfoAluno.CidadeDoAluno;
            aluno.Logradouro = InfoAluno.LogradouroDoAluno;
            aluno.Bairro = InfoAluno.BairroDoAluno;
            aluno.Numero = InfoAluno.NumeroDoAluno;

            // DADOS DO RESPONSÁVEL DO ALUNO
            aluno.Responsavel.Nome = InfoAluno.NomeResponsavelDoAluno;
            aluno.Responsavel.RG_Documento = InfoAluno.RG_DocumentoReponsavelDoAluno;
            aluno.Responsavel.Profissao = InfoAluno.ProfissaoResponsavelDoAluno;
            aluno.Responsavel.DataNascimento = InfoAluno.DataNascimentoResponsavelDoAluno;

            // DADOS DE CONTATO DOS RESPONSÁVEL DO ALUNO
            aluno.Responsavel.Email = InfoAluno.EmailResponsavelDoAluno;
            aluno.Responsavel.Tel1 = InfoAluno.Tel1ResponsavelDoAluno;
            aluno.Responsavel.Tel2 = InfoAluno.Tel2ResponsavelDoAluno;

            CadastrarAluno(aluno);
        }

        public void CadastrarAluno(Aluno alunoInfo)
        {
            Console.WriteLine("Obtendo Coleção(Tabela) de Alunos...");
            IMongoCollection<Aluno> aluno = MongoDBDataBase.GetConnect.GetCollection<Aluno>("Alunos");

            AlunoDAO alunoDAO = new AlunoDAO();

            alunoDAO.CadastrarAluno(aluno, alunoInfo);
        }

        public void CarregarAlunos()
        {
            // Busca da base todos os alunos Cadastrados
            _listaAlunos = _dataBaseServiceJSON.DeserializarNewtonsoft<Aluno>("Usuarios.json", string.Concat(Environment.CurrentDirectory, @"\DataBaseSchoolCommunity\"));
        }

        public void PopulaAlunos()
        {

        }

        public void ListarEstadosDropDownList()
        {
            _listaUF_Cidades = new List<Estados>();
            _listaUF_Cidades = _dataBaseServiceJSON.DeserializarNewtonsoft<Estados>("Estados_Cidades.json", string.Concat(Environment.CurrentDirectory, @"\DataBaseSchoolCommunity\"));
        }

        public void ListarCidadesDropDownList(string sigla)
        {
            var teste = _listaUF_Cidades.FindAll(x => x.Sigla == sigla);
        }
    }
}