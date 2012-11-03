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

        public ViewResult Index()
        {
            return View(db.Boletos.ToList());
        }

        //
        // GET: /Boletos/Details/5

        public ViewResult Details(int id)
        {
            Boleto boleto = db.Boletos.Find(id);
            return View(boleto);
        }

        //
        // GET: /Boletos/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Boletos/Create

        [HttpPost]
        public ActionResult Create(Boleto boleto)
        {
            if (ModelState.IsValid)
            {
                db.Boletos.Add(boleto);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(boleto);
        }
        
        //
        // GET: /Boletos/Edit/5
 
        public ActionResult Edit(int id)
        {
            Boleto boleto = db.Boletos.Find(id);
            return View(boleto);
        }

        //
        // POST: /Boletos/Edit/5

        [HttpPost]
        public ActionResult Edit(Boleto boleto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boleto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}