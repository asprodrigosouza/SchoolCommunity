using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SchoolCommunity.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.ViewComponents
{
    public class CalendarioAnualViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(string fluxo, IMongoDatabase mongoDataBaseConn)
        {
            
            return View("CalendarioAnual");
        }

    }
}
