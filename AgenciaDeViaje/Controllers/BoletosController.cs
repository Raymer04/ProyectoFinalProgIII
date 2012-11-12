using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgenciaDeViaje.Models;

namespace AgenciaDeViaje.Controllers
{ 
    public class BoletosController : Controller
    {
        private AgenciaDB db = new AgenciaDB();

        //
        // GET: /Boletos/

        public ActionResult Index(int tipo)
        {
            if (Session["usuario"] != null)
            {

                Cliente cliente = (Cliente)Session["usuario"];
                return View(db.Boletos.Where(p => p.tipo == tipo).ToList());
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Clients");
            }
            
           
        }
        public ActionResult ManejoBoleto(int tipo, int id) {
            Boleto boleto = new Boleto();
            ServicioWeb.ServicioDeComunicacionSoapClient sw=new ServicioWeb.ServicioDeComunicacionSoapClient();
            Vuelo vuelo = new Vuelo();
            var a=sw.TodosVuelos().First(v => v.Id == id);
            vuelo.Destino = a.DestinoReference.ToString();
            vuelo.Procedencia = a.ProcedenciaReference.ToString();
            vuelo.Salida = (DateTime)a.Salida;
            vuelo.Llegada =(DateTime) a.Llegada;

            if(tipo==1){
                boleto.tipo = 1;
                boleto.vuelo=vuelo;
                db.Boletos.Add(boleto);
                return RedirectToAction("Index?tipo=1", "Boletos");
            }else if(tipo==2){
                boleto.tipo = 2;
                boleto.vuelo=vuelo;
                db.Boletos.Add(boleto);
                return RedirectToAction("Index?tipo=2", "Boletos");
            }else if(tipo==3){
                boleto.tipo = 3;
                boleto.vuelo = vuelo;
                db.Boletos.Add(boleto);
                return RedirectToAction("Index?tipo=3", "Boletos");
            }
            return RedirectToAction("Index","Home");
        }
        //
        // GET: /Boletos/Details/5

        public ViewResult Details(int id)
        {
            Boleto boleto = db.Boletos.Find(id);
            return View(boleto);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}