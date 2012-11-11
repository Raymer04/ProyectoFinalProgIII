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
            var query2 = a.TodosVuelos().Select(x => new {x.ID, x.DestinoReference });//.Aeropuerto.Select(a => new { a.Id, a.Lugar });
            ViewBag.Destinos = new SelectList(query2.AsEnumerable(), "Id", "Lugar");
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
