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
                List<Boleto> lista = new List<Boleto>(); 
                
                var a=db.Clientes.Select(p => p.boletos.Where(x => x.tipo == tipo)).ToList();
                foreach(Boleto dato in a){
                    Boleto boleto = new Boleto();
                    boleto.Id = dato.Id;
                    boleto.tipo = dato.tipo;
                    boleto.vuelo = dato.vuelo;
                    lista.Add(boleto);
                }
                return View(lista);
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Clients");
            }
            
           
        }
        public ActionResult ManejoBoleto(int tipo, int id) {
            if (Session["usuario"] != null)
            {
                ServicioWeb.ServicioDeComunicacionSoapClient servicio=new ServicioWeb.ServicioDeComunicacionSoapClient();
                Boleto boleto = new Boleto();

                if (servicio.asientosDisponibles(id)== 0)
                {
                    this.ListaEspera(id);
                }else{
                if (tipo == 1)
                {
                    boleto.tipo = 1;
                    boleto.vuelo = id;
                    db.Boletos.Add(boleto);
                    return RedirectToAction("Index?tipo=1", "Boletos");
                }
                else if (tipo == 2)
                {
                    boleto.tipo = 2;
                    boleto.vuelo = id;
                    db.Boletos.Add(boleto);
                    return RedirectToAction("Index?tipo=2", "Boletos");
                }
                }
            }
            return RedirectToAction("IniciarSesion", "Clients");
        }
        //
        // GET: /Boletos/Details/5

        public ViewResult Details(int id)
        {
            Boleto boleto = db.Boletos.Find(id);
            return View(boleto);
        }

        //
        // GET: /Boletos/Delete/5

        public ActionResult Delete(int id)
        {
            Boleto boleto = db.Boletos.Find(id);
            return View(boleto);
        }

        //
        // POST: /Boletos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Boleto boleto = db.Boletos.Find(id);
            db.Boletos.Remove(boleto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ListaEspera(int id)
        {
                           
            return View(id);
        }

        //
        // POST: /Boletos/Delete/5

        [HttpPost, ActionName("AgregarListaEspera")]
        public ActionResult ListaEsperaConfirmar(int id)
        {
            Boleto boleto = new Boleto();

            boleto.tipo = 3;
            boleto.vuelo = id;
            db.Boletos.Add(boleto);
            db.SaveChanges();
            return RedirectToAction("Index?tipo=3", "Boletos");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}