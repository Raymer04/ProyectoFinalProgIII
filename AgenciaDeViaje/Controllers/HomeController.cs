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
            var aux = a.TodosVuelos().Select(x => new {x.ID, x.DestinoReference.EntityKey.EntityKeyValues });
            ViewBag.Destinos = new SelectList(aux.AsEnumerable(), "Id", "DestinoID");
             
            var aux2 = a.TodosVuelos().Select(x => new { x.ID, x.Llegada });
            ViewBag.Procedencia = new SelectList(aux2.AsEnumerable(), "Id", "Llegada");
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
