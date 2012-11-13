using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LineaAerea.Models;

namespace LineaAerea.Controllers
{ 
    public class AvionController : Controller
    {
        private LineaAereaDB db = new LineaAereaDB();

        //
        // GET: /Avion/

        public ActionResult Index()
        {
            if (Session["usuario"] != null)
            {
                return View(db.Avion.ToList());
            }
            else {
                return RedirectToAction("IniciarSesion", "Usuarios");
            }
        }

        //
        // GET: /Avion/Details/5

        public ViewResult Details(int id)
        {
            Avion avion = db.Avion.Find(id);
            return View(avion);
        }

        //
        // GET: /Avion/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Avion/Create

        [HttpPost]
        public ActionResult Create(Avion avion)
        {
            if (ModelState.IsValid)
            {
                db.Avion.Add(avion);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(avion);
        }
        
        //
        // GET: /Avion/Edit/5
 
        public ActionResult Edit(int id)
        {
            Avion avion = db.Avion.Find(id);
            return View(avion);
        }

        //
        // POST: /Avion/Edit/5

        [HttpPost]
        public ActionResult Edit(Avion avion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(avion);
        }

        //
        // GET: /Avion/Delete/5
 
        public ActionResult Delete(int id)
        {
            Avion avion = db.Avion.Find(id);
            return View(avion);
        }

        //
        // POST: /Avion/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Avion avion = db.Avion.Find(id);
            db.Avion.Remove(avion);
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