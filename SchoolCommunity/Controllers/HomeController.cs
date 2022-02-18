using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolCommunity.DataBase;
using SchoolCommunity.Models;
using SchoolCommunity.Models.ViewModels;
using SchoolCommunity.Services;

namespace SchoolCommunity.Controllers
{
    public class HomeController : Controller
    {
        public UserService _userService;

        public HomeController()
        {
            _userService = new UserService();
        }

        public IActionResult Index()
        {
            if (CheckSession())
            {
                return View();
            }
            else
            {
                return Redirect(_userService.GetRedirectLogin());
            }
        }

        public IActionResult MeuPerfil()
        {
            if (CheckSession())
            {
                return View();
            }
            else
            {
                return Redirect(_userService.GetRedirectLogin());
            }
        }

        public IActionResult BoletimEscolar()
        {
            if (CheckSession())
            {
                return View();
            }
            else
            {
                return Redirect(_userService.GetRedirectLogin());
            }
        }

        public IActionResult CronogramaAulas()
        {
            if (CheckSession())
            {
                return View();
            }
            else
            {
                return Redirect(_userService.GetRedirectLogin());
            }
        }

        public IActionResult Forum()
        {
            if (CheckSession())
            {
                return View();
            }
            else
            {
                return Redirect(_userService.GetRedirectLogin());
            }
        }

        public IActionResult FrequenciaEscolar()
        {
            if (CheckSession())
            {
                return View();
            }
            else
            {
                return Redirect(_userService.GetRedirectLogin());
            }
        }

        public IActionResult Calendario()
        {
            if (CheckSession())
            {
                return View();
            }
            else
            {
                return Redirect(_userService.GetRedirectLogin());
            }
        }

        public IActionResult EventosAgendados()
        {
            EventoVM eventoVM = new EventoVM();
            
            var listaDeEventosAgendados = eventoVM.ListarEventosAgendados();

            return Json(listaDeEventosAgendados.Select(e => new {
                idEvento = e._id.ToString(),
                title = e.Nome,
                description = e.DescricaoObservacao,
                start = e.DataInicio,
                dataFimEvento = e.DataFim
            }));
        }

        [HttpPost]
        public string ValidarLoginSenha([FromBody]string dadosUsuario)
        {
            // ******* STATUS ******* //

            // 0 - Usuario OK
            // 1 - Senha ou Usuário Invalido
            // 2 - Usuario Inativo
            // 3 - Mudar Senha

            if (!string.IsNullOrEmpty(dadosUsuario))
            {
                var usr = new UsuarioVM
                {
                    LoginUsuario = dadosUsuario.Split("|")[0],
                    SenhaUsuario = dadosUsuario.Split("|")[1],
                    PerfilUsuario = dadosUsuario.Split("|")[2]
                };

                if (_userService.Autenticar(usr))
                {
                    Helpers.ValidaAcessoUsuario validaAcessoUsuario = new Helpers.ValidaAcessoUsuario();

                    if (validaAcessoUsuario.UsuarioAtivo(usr))
                    {
                        if (validaAcessoUsuario.UsuarioPrimeiroAcesso(usr))
                        {
                            _userService.AtualizaDadosSessao(usr, HttpContext.Session);
                            return "3";
                        }
                        else
                        {
                            _userService.AtualizaDadosSessao(usr, HttpContext.Session);
                            return "0";
                        }
                        
                    }
                    else
                    {
                        return "2";
                    }
                    
                }
                else
                {
                    return "1";
                }
            }
            return "-1";
        }
        
        // MODO 2 -> form[name='validatelogin']
        //[HttpPost]
        //public string ValidarLoginSenha(UsuarioVM usuario)
        //{
        //    if (_userService.Autenticar(usuario))
        //    {
        //        _userService.AtualizaDadosSessao(usuario, HttpContext.Session);
        //        return "0";
        //    }
        //    else
        //    {
        //        return "1";
        //    }
        //}

        public bool CheckSession()
        {
            if ((HttpContext.Session.IsAvailable && _userService.ValidaSessaoUsuario(HttpContext.Session)))
            {
                ViewData["NomeUsuario"] = _userService.ObtemDadosSessao(HttpContext.Session).NomeUsuario;
                ViewData["PerfilUsuario"] = _userService.ObtemDadosSessao(HttpContext.Session).PerfilUsuario;
                return true;
            }
            else
            {
                return false;
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect(_userService.GetRedirectLogin());
        }

        public IActionResult CadastrarAluno()
        {
            if (CheckSession())
            {
                return View();
            }
            else
            {
                return Redirect(_userService.GetRedirectLogin());
            }
        }

        public IActionResult CadastrarEvento()
        {
            if (CheckSession())
            {
                return View();
            }
            else
            {
                return Redirect(_userService.GetRedirectLogin());
            }
        }

        public IActionResult CadastrarTurma()
        {
            if (CheckSession())
            {
                return View();
            }
            else
            {
                return Redirect(_userService.GetRedirectLogin());
            }
        }

        public IActionResult MudarSenha()
        {
            if (CheckSession())
            {
                return View();
            }
            else
            {
                return Redirect(_userService.GetRedirectLogin());
            }
        }

        public IActionResult CadastrarAusenciaEscolar()
        {
            if (CheckSession())
            {
                return View();
            }
            else
            {
                return Redirect(_userService.GetRedirectLogin());
            }
            
        }

        [HttpPost]
        public IActionResult AbrirCadastroTurma([FromBody] string value)
        {
            int idFluxo = 0;
            long idCadastro = 0;

            long id = 0;
            Int64.TryParse(value, out id);

            if (id > 0)
            {
                idFluxo = 1;
            }
            idCadastro = 1;

            return ViewComponent("ModalFormCadastrarTurma", new { fluxo = idFluxo, cadastro = idCadastro });
        }

        [HttpPost]
        public IActionResult CadastrarTurmaViewComponent([FromBody] TurmaVM Turma)
        {
            int Fluxo = 1;
            return ViewComponent("ModalFormCadastrarTurma", new { Turma, Fluxo });
        }

        [HttpPost]
        public IActionResult EditarAtualizarTurmaViewComponent([FromBody] TurmaVM Turma)
        {
            int Fluxo = 3;
            return ViewComponent("ModalFormCadastrarTurma", new { Turma, Fluxo});
        }

        public IActionResult AtualizarTurmasCadastradas()
        {
            return ViewComponent("TurmasCadastradas", MongoDBDataBase.GetConnect);
        }

        [HttpPost] 
        public IActionResult AbrirConfigCadastroTurma([FromBody] string idTurma)
        {
            int Fluxo = 2;
            
            return ViewComponent("ModalFormCadastrarTurma", new { Fluxo, idTurma });
        }

        [HttpPost]
        public IActionResult CadastrarAusenciaEscolarViewComponent([FromBody] AusenciaEscolarVM Ausencia)
        {
            string Fluxo = "0";
            
            return ViewComponent("FormCadastrarAusencia", new { Ausencia, Fluxo });
        }
        
        [HttpPost]
        public IActionResult CadastrarAluno([FromBody] AlunoVM Aluno)
        {
            string Fluxo = "0";
            
            return ViewComponent("FormCadastrarAluno", new { Aluno, Fluxo });
        }

        [HttpPost]
        public IActionResult CadastrarEventoViewComponent([FromBody] EventoVM evento)
        {
            string fluxo = "0";
            
            return ViewComponent("FormCadastrarEvento", new { evento, fluxo });
        }

        [HttpPost]
        public IActionResult PostarPerguntaForum([FromBody] ForumVM Pergunta)
        {
            string Fluxo = "0";
            //MongoDBDataBase mongoDBDataBase = new MongoDBDataBase();
            //var pocDataBaseMongoConn = mongoDBDataBase.GetConnect();
            return ViewComponent("Forum", new { Pergunta, Fluxo/*, pocDataBaseMongoConn*/ });
        }

        [HttpPost]
        public IActionResult PostarRespostaForum([FromBody] string value)
        {
            var dados = value.Split("|");

            var idPergunta = dados[0];
            var descResposta = dados[1];

            string Fluxo = "1";

            //MongoDBDataBase mongoDBDataBase = new MongoDBDataBase();
            //var pocDataBaseMongoConn = mongoDBDataBase.GetConnect();
            
            return ViewComponent("ModalPerguntaForum", new { idPergunta, descResposta, Fluxo/*, pocDataBaseMongoConn*/ });
        }

        public IActionResult AtualizarTopicosRecentes()
        {
            return ViewComponent("Forum");
        }

        [HttpPost]
        public IActionResult AbrirModalPergunta([FromBody] string idPergunta)
        {
            string Fluxo = "0";
            string descResposta = "";
            return ViewComponent("ModalPerguntaForum", new { idPergunta, descResposta, Fluxo });
        }
    }
}
