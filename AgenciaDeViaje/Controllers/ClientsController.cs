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
    public class ClientsController : Controller
    {
        private AgenciaDB db = new AgenciaDB();

        
        //
        // GET: /Clients/Details/5

        public ActionResult  Details()
        {
            if (Session["usuario"] != null)
            {
                
                Cliente cliente = (Cliente)Session["usuario"];
                return View(cliente);
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Clients");
            }
            
        }

        //
        // GET: /Clients/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Clients/Create

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (db.Clientes.Count(p => p.correo == cliente.correo) == 0)
                {
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                    return RedirectToAction("IniciarSesion", "Clients");
                }
                else {
                    ViewBag.msj2 = "Este Correo Ya Existe Intente Con Otro";
                }
                
            }

            return View(cliente);
        }
        
        //
        // GET: /Clients/Edit/5
 
        public ActionResult Edit(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            return View(cliente);
        }

        //
        // POST: /Clients/Edit/5

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(cliente);
        }

        //
        // GET: /Clients/Delete/5
 
        public ActionResult Delete(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            return View(cliente);
        }

        //
        // POST: /Clients/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.Salir();
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult IniciarSesion()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(IniciarSesion model, string returnUrl)
        {
            if (db.Clientes.Count(p => p.correo == model.Correo && p.password == model.Password) > 0)
            {
                Cliente cliente = db.Clientes.Where(p => p.correo == model.Correo && p.password == model.Password).First();
                Session["usuario"] = cliente;
                Session["nombre"] = cliente.nombre + " " + cliente.apellido;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.msj = "Correo o Clave Inconrecta";
                return View(model);
            }
        }

        public ActionResult Salir()
        {
            Session["usuario"] = null;
            return RedirectToAction("Index", "Home");
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}