using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.ViewComponents
{
    public class FrequenciaEscolarViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
