using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Locadora.Web.MVC.Seguranca;

namespace Locadora.Web.MVC.Controllers
{
    [Autorizador]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}