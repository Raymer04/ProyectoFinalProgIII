using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgenciaDeViaje.Models;

namespace AgenciaDeViaje.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Bienvenidos a nuestra agencia de viajes";

            return View();
        }
        [HttpPost]
        public ActionResult Index(Vuelo model)
        {
            
            return RedirectToAction("Index", "vuelo");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
