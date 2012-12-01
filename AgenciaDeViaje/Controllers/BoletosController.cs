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
               ServicioWeb.ServicioDeComunicacionSoapClient servicio=new ServicioWeb.ServicioDeComunicacionSoapClient();
                Vuelo vuelo=new Vuelo();
               
                var boletoes = db.Boletos.Include(b => b.Vuelo).Where(p=>p.Cliente.Id==cliente.Id && p.tipo==tipo);
               foreach(var a in boletoes){
                    
                   a.BoletoCargar();
               }
                return View(boletoes.ToList());

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

                    return RedirectToAction("ListaEspera", "Boletos", new { id =id });
                }else{
                if (tipo == 1)
                {
                    boleto.tipo = 1;
                    boleto.RefIdVuelo = id;
                    boleto.RefIdCliente = ((Cliente)Session["usuario"]).Id;
                    db.Boletos.Add(boleto);
                    if(db.SaveChanges()>0){
                    
                    }
                    

                    return RedirectToAction("Index", "Boletos",new{tipo=1});
                }
                else if (tipo == 2)
                {
                    boleto.tipo = 2;
                    boleto.RefIdVuelo = id;
                    boleto.RefIdCliente = ((Cliente)Session["usuario"]).Id;
                    db.Boletos.Add(boleto);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Boletos",new{tipo=2});
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
            boleto.BoletoCargar();
            return View(boleto);
        }

        //
        // GET: /Boletos/Delete/5


        public ActionResult Delete(int id)
        {
            Boleto boleto = db.Boletos.Find(id);
            db.Boletos.Remove(boleto);
            db.SaveChanges();
            try
            {

                Response.Redirect(Request.UrlReferrer.ToString());
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ListaEspera(int id)
        {
                           
            return View();
        }

        //
        // POST: /Boletos/Delete/5

        [HttpPost, ActionName("ListaEspera")]
        public ActionResult ListaEsperaConfirmar(int id)
        {
            Boleto boleto = new Boleto();

            boleto.tipo = 3;
            boleto.RefIdVuelo = id;
            boleto.RefIdCliente = ((Cliente)Session["usuario"]).Id;
            db.Boletos.Add(boleto);
            db.SaveChanges();
            return RedirectToAction("Index", "Boletos", new { tipo=3});
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}