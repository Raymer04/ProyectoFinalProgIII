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
            
                ServicioWeb.ServicioDeComunicacionSoapClient a = new ServicioWeb.ServicioDeComunicacionSoapClient();
                
                var b = a.VuelosDisponibles(Convert.ToInt32(model.Procedencia), Convert.ToInt32(model.Destino), model.Salida);
                //var b = a.TodosVuelos();
               ViewBag.aeropuertos= a.Aeropuertos().ToList();
              
                List<Vuelo> vuelos = new List<Vuelo>();
                DateTime hora = new DateTime(2012, 10, 16, 20, 0, 0, 0);
            
                foreach (var dato in b)
                {
                    
                    Vuelo vuelo = new Vuelo();
                    vuelo.Salida =  dato.FechaSalida;
                    vuelo.Llegada = hora;//dato.Llegada;
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
