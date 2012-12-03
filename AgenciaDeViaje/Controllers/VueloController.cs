using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgenciaDeViaje.Models;

namespace AgenciaDeViaje.Controllers
{
    public class VueloController : Controller
    {
          
        private AgenciaDB db = new AgenciaDB();
        
        public ActionResult BuscarVuelo(Vuelo model)
        {
            var b = (ServicioWeb.Vuelo[])null;
               ServicioWeb.ServicioDeComunicacionSoapClient a = new ServicioWeb.ServicioDeComunicacionSoapClient();
               if (model.Modo.Equals("Ida")) {
                   b=a.VuelosIda(Convert.ToInt32(model.Procedencia),
                       Convert.ToInt32(model.Destino), model.Salida);
               }
               else if (model.Modo.Equals("Ida y Vuelta")) {
                  b = a.VuelosIdaVuelta(Convert.ToInt32(model.Procedencia),
                      Convert.ToInt32(model.Destino), model.Salida, model.Llegada);
               }
              
            ViewBag.aeropuertos= a.Aeropuertos().ToList();
              
                List<Vuelo> vuelos = new List<Vuelo>();
            
                foreach (var dato in b)
                {
                    
                    Vuelo vuelo = new Vuelo();
                    string[] time=dato.HoraSalida.Split(':');
                    string[] min = time[1].Split(' ');
                    vuelo.Salida = dato.FechaSalida.AddHours(Convert.ToInt32(time[0])).AddMinutes(Convert.ToInt32(min[0]));
                    vuelo.Llegada = vuelo.Salida.AddHours(dato.Duracion);
                    vuelo.Id = dato.Id;
                    vuelo.Destino = a.Aeropuertos().ToList().Find(p => p.Id == (Int32)dato.AeropuertoReference.EntityKey.EntityKeyValues.First().Value).Lugar;
                    vuelo.Procedencia = a.Aeropuertos().ToList().Find(p => p.Id == (Int32)dato.Aeropuerto1Reference.EntityKey.EntityKeyValues.First().Value).Lugar;
                    vuelos.Add(vuelo);
                }

                if (vuelos.Count == 0) {
                    TempData["error"] = "No encontramos ningun vuelo que coincida con tu busqueda";
                    return RedirectToAction("Index", "Home");
                }
                
                return View(vuelos);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
    
}
