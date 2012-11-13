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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
    
}
