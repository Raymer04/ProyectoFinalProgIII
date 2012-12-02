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

            ViewBag.Destinos = new SelectList(a.Aeropuertos(), "Id", "Lugar");
            ViewBag.Procedencia = new SelectList(a.Aeropuertos(), "Id", "Lugar");

            return View();
        }
        [HttpPost]
        public ActionResult Index(Vuelo model)
        {
            
            return RedirectToAction("BuscarVuelo", "Vuelo",model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
