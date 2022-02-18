using Microsoft.AspNetCore.Mvc;
using SchoolCommunity.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.ViewComponents
{
    public class BoletimEscolarViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var model = new BoletimEscolarVM();
            return View(model);
        }

    }
}
