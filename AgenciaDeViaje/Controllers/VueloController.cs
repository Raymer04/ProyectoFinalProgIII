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
            return View();
           
           
<<<<<<< HEAD
          ServicioWeb.ServicioDeComunicacionSoapClient a = new ServicioWeb.ServicioDeComunicacionSoapClient();
         
            var b= a.VuelosDisponibles(model.Procedencia, model.Destino, model.Salida);

            List<Vuelo> vuelos = new List<Vuelo>();
              foreach (var dato in b)
              {
                  Vuelo vuelo = new Vuelo();
                  vuelo.Destino = dato.AeropuertoReference.ToString();
                  vuelo.Procedencia = dato.Aeropuerto1Reference.ToString();
                 
                  vuelos.Add(vuelo);
                  
           
              }
            return View(vuelos);
            
=======
>>>>>>> 804e43fa82440202f04e7a7bef9294eab558b390
        }

        //
        // GET: /Vuelo/Details/5

        public ViewResult Details(int id)
        {
            Vuelo vuelo = db.Vueloes.Find(id);
            return View(vuelo);
        }

<<<<<<< HEAD
        
=======

        public ActionResult BuscarVuelo(Vuelo model)
        {
            // return View(db.Vueloes.ToList());

                ServicioWeb.ServicioDeComunicacionSoapClient a = new ServicioWeb.ServicioDeComunicacionSoapClient();

                //  DataGrid vuelosDisponibles = new DataGrid();

                //Vuelo.vuelosDisponibles.AutoGenerateColumns = true;
                //vuelosDisponibles.DataSource = a.VuelosDisponibles(model.Procedencia, model.Destino, model.Salida);
                //  System.Collections.Generic.IEnumerable<AgenciaDeViaje.Models.Vuelo> lista;
                var b = a.VuelosDisponibles(model.Procedencia, model.Destino, model.Salida);

                List<Vuelo> vuelos = new List<Vuelo>();
                foreach (var dato in b)
                {
                    Vuelo vuelo = new Vuelo();
                    vuelos.Add(vuelo);


                }
                return View(vuelos);
            
         
            
        }

>>>>>>> 804e43fa82440202f04e7a7bef9294eab558b390
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
    
}
