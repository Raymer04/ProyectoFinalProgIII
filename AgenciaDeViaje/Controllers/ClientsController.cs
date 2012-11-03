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
        // GET: /Clients/

        public ViewResult Index()
        {
            return View(db.Clientes.ToList());
        }

        //
        // GET: /Clients/Details/5

        public ViewResult Details(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            return View(cliente);
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
                
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");  
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
                return RedirectToAction("Index");
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
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}