using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Aluno()
        {
            return View();
        }

        public IActionResult Funcionario()
        {
            return View();
        }

        public IActionResult Responsavel()
        {
            return View();
        }
    }
}
