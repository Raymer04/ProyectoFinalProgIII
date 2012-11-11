using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgenciaDeViaje.Models;
using System.Web.UI.WebControls;


namespace AgenciaDeViaje.Controllers
{ 
    public class VueloController : Controller
    {

        
        private AgenciaDB db = new AgenciaDB();
        
        //
        // GET: /Vuelo/

        public ViewResult Index(Vuelo model)
        {
            
           // return View(db.Vueloes.ToList());
            ServicioWeb.ServicioDeComunicacionSoapClient a = new ServicioWeb.ServicioDeComunicacionSoapClient();

          //  DataGrid vuelosDisponibles = new DataGrid();

            //Vuelo.vuelosDisponibles.AutoGenerateColumns = true;
            //vuelosDisponibles.DataSource = a.VuelosDisponibles(model.Procedencia, model.Destino, model.Salida);
          //  System.Collections.Generic.IEnumerable<AgenciaDeViaje.Models.Vuelo> lista;
            var b= a.VuelosDisponibles(model.Procedencia, model.Destino, model.Salida);

            List<Vuelo> vuelos = new List<Vuelo>();
              foreach (var dato in b)
              {
                  Vuelo vuelo = new Vuelo();
                  vuelo.Destino = dato.DestinoReference.ToString();
                  vuelo.Procedencia = dato.ProcedenciaReference.ToString();
                 
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

        
/*
        public ActionResult BuscarVuelos(Vuelo model)
        {
           
        }*/

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}