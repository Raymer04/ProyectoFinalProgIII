using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgenciaDeViaje.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Bienvenidos a nuestra agencia de viajes";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
