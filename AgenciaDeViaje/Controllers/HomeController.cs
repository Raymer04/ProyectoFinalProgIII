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
          
            ServicioWeb.ServicioDeComunicacionSoapClient a = new ServicioWeb.ServicioDeComunicacionSoapClient();
            ViewBag.Message = "Bienvenidos a nuestra agencia de viajes";

            var aux = a.Aeropuertos().Select(x => new {x.Id,x.Lugar});
            ViewBag.Destinos = new SelectList(aux.AsEnumerable(), "Id", "Lugar");

            var aux2 = a.Aeropuertos().Select(x => new { x.Id, x.Lugar });
            ViewBag.Procedencia = new SelectList(aux2.AsEnumerable(), "Id", "Lugar");
            return View();
        }
        [HttpPost]
        public ActionResult Index(Vuelo model)
        {
            
            return RedirectToAction("BuscarVuelo", "Vuelo");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
