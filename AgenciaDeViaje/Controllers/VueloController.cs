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
            var n = (ServicioWeb.Vuelo[])null;
            List<Vuelo> vuelos = new List<Vuelo>();
            ServicioWeb.ServicioDeComunicacionSoapClient a = new ServicioWeb.ServicioDeComunicacionSoapClient();
            Session.Contents.RemoveAll();

            if (model.Modo.Equals("Ida"))
            {
                b = a.VuelosIda(Convert.ToInt32(model.Procedencia),
                    Convert.ToInt32(model.Destino), model.Salida);

                ViewBag.aeropuertos = a.Aeropuertos().ToList();



                foreach (var dato in b)
                {
                    vuelos = new List<Vuelo>();
                    Vuelo vuelo = new Vuelo();
                    string[] time = dato.HoraSalida.Split(':');
                    string[] min = time[1].Split(' ');
                    vuelo.Salida = dato.FechaSalida.AddHours(Convert.ToInt32(time[0])).AddMinutes(Convert.ToInt32(min[0]));
                    vuelo.Llegada = vuelo.Salida.AddHours(dato.Duracion);
                    vuelo.Id = dato.Id;
                    vuelo.Destino = a.Aeropuertos().ToList().Find(p => p.Id == (Int32)dato.AeropuertoReference.EntityKey.EntityKeyValues.First().Value).Lugar;
                    vuelo.Procedencia = a.Aeropuertos().ToList().Find(p => p.Id == (Int32)dato.Aeropuerto1Reference.EntityKey.EntityKeyValues.First().Value).Lugar;
                    vuelos.Add(vuelo);
                    Session["Ida"] = vuelos;
                }

                if (vuelos==null)
                {
                    TempData["error"] = "No encontramos ningun vuelo que coincida con tu busqueda";
                    return RedirectToAction("Index", "Home");
                }
            }
            else if (model.Modo.Equals("Ida y Vuelta"))
            {
                n = a.VuelosVuelta(Convert.ToInt32(model.Procedencia),
                    Convert.ToInt32(model.Destino), model.Salida, model.Llegada);

                b = a.VuelosIda(Convert.ToInt32(model.Procedencia),
                    Convert.ToInt32(model.Destino), model.Salida);

                ViewBag.aeropuertos = a.Aeropuertos().ToList();
                Session.Contents.RemoveAll();



                foreach (var dato in b)
                {
                   
                    vuelos = new List<Vuelo>();
                    Vuelo vuelo = new Vuelo();
                    string[] time = dato.HoraSalida.Split(':');
                    string[] min = time[1].Split(' ');
                    vuelo.Salida = dato.FechaSalida.AddHours(Convert.ToInt32(time[0])).AddMinutes(Convert.ToInt32(min[0]));
                    vuelo.Llegada = vuelo.Salida.AddHours(dato.Duracion);
                    vuelo.Id = dato.Id;
                    vuelo.Destino = a.Aeropuertos().ToList().Find(p => p.Id == (Int32)dato.AeropuertoReference.EntityKey.EntityKeyValues.First().Value).Lugar;
                    vuelo.Procedencia = a.Aeropuertos().ToList().Find(p => p.Id == (Int32)dato.Aeropuerto1Reference.EntityKey.EntityKeyValues.First().Value).Lugar;
                    vuelos.Add(vuelo);
                    Session["Ida"] = vuelos;
                }

                foreach (var dato in n)
                {
                    vuelos = new List<Vuelo>();
                    Vuelo vuelo = new Vuelo();
                    string[] time = dato.HoraSalida.Split(':');
                    string[] min = time[1].Split(' ');
                    vuelo.Salida = dato.FechaSalida.AddHours(Convert.ToInt32(time[0])).AddMinutes(Convert.ToInt32(min[0]));
                    vuelo.Llegada = vuelo.Salida.AddHours(dato.Duracion);
                    vuelo.Id = dato.Id;
                    vuelo.Destino = a.Aeropuertos().ToList().Find(p => p.Id == (Int32)dato.AeropuertoReference.EntityKey.EntityKeyValues.First().Value).Lugar;
                    vuelo.Procedencia = a.Aeropuertos().ToList().Find(p => p.Id == (Int32)dato.Aeropuerto1Reference.EntityKey.EntityKeyValues.First().Value).Lugar;
                    vuelos.Add(vuelo);
                    Session["IdaVuelta"] = vuelos;
                }

                if (vuelos.Count == 0)
                {
                    TempData["error"] = "No encontramos ningun vuelo que coincida con tu busqueda";
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


    }
    
}
