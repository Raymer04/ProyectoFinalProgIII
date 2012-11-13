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
        
        //
        // GET: /Vuelo/
        
        public ViewResult Index(Vuelo model)
        {
            //return View();
           
           

          ServicioWeb.ServicioDeComunicacionSoapClient a = new ServicioWeb.ServicioDeComunicacionSoapClient();
         
            var b= a.VuelosDisponibles(model.Procedencia, model.Destino, model.Salida);

            List<Vuelo> vuelos = new List<Vuelo>();
              foreach (var dato in b)
              {
                  Vuelo vuelo = new Vuelo();
                  vuelo.Destino = Int32.Parse(dato.AeropuertoReference.ToString());
                  vuelo.Procedencia = Int32.Parse(dato.Aeropuerto1Reference.ToString());
                 
                  vuelos.Add(vuelo);
                  
           
              }
            return View(vuelos);
            
        }

        //
        // GET: /Vuelo/Details/5

        public ViewResult Details(int id)
        {
            Vuelo vuelo = db.Vueloes.Find(id);
            return View(vuelo);
        }

        public ActionResult BuscarVuelo(Vuelo model)
        {
            
                ServicioWeb.ServicioDeComunicacionSoapClient a = new ServicioWeb.ServicioDeComunicacionSoapClient();

                var b = a.VuelosDisponibles(model.Procedencia, model.Destino, model.Salida);

                List<Vuelo> vuelos = new List<Vuelo>();
                foreach (var dato in b)
                {
                    Vuelo vuelo = new Vuelo();
                    vuelos.Add(vuelo);


                }

                Vuelo vueloTest = new Vuelo();
                vueloTest.Destino = 1;
                vueloTest.Procedencia = 2;
                vueloTest.Id = 1;
                vuelos.Add(vueloTest);
                return View(vuelos);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
    
}
