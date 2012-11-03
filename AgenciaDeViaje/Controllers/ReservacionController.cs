using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgenciaDeViaje.Controllers
{
    public class ReservacionController : Controller
    {
        //
        // GET: /Vuelos/

        public ActionResult HorarioVuelos()
        {
            return View();
        }

        public ActionResult Reservacion()
        {
            return View();
        }
    }
}
