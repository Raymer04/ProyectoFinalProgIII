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
    public class VueloController : Controller
    {
        private LineaAereaDB db = new LineaAereaDB();

        //
        // GET: /Vuelo/

        public ViewResult Index()
        {
            var vuelo = db.Vuelo.Include(v => v.Procedencia).Include(v => v.Destino);
            return View(vuelo.ToList());
        }

        //
        // GET: /Vuelo/Details/5

        public ViewResult Details(int id)
        {
            Vuelo vuelo = db.Vuelo.Find(id);
            return View(vuelo);
        }

        //
        // GET: /Vuelo/Create

        public ActionResult Create()
        {
            ViewBag.ProcedenciaID = new SelectList(db.Aeropuerto, "Id", "Lugar");
            ViewBag.DestinoID = new SelectList(db.Aeropuerto, "Id", "Lugar");
            return View();
        } 

        //
        // POST: /Vuelo/Create

        [HttpPost]
        public ActionResult Create(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                db.Vuelo.Add(vuelo);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ProcedenciaID = new SelectList(db.Aeropuerto, "Id", "Nombre", vuelo.ProcedenciaID);
            ViewBag.DestinoID = new SelectList(db.Aeropuerto, "Id", "Nombre", vuelo.DestinoID);
            return View(vuelo);
        }
        
        //
        // GET: /Vuelo/Edit/5
 
        public ActionResult Edit(int id)
        {
            Vuelo vuelo = db.Vuelo.Find(id);
            ViewBag.ProcedenciaID = new SelectList(db.Aeropuerto, "Id", "Nombre", vuelo.ProcedenciaID);
            ViewBag.DestinoID = new SelectList(db.Aeropuerto, "Id", "Nombre", vuelo.DestinoID);
            return View(vuelo);
        }

        //
        // POST: /Vuelo/Edit/5

        [HttpPost]
        public ActionResult Edit(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vuelo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProcedenciaID = new SelectList(db.Aeropuerto, "Id", "Nombre", vuelo.ProcedenciaID);
            ViewBag.DestinoID = new SelectList(db.Aeropuerto, "Id", "Nombre", vuelo.DestinoID);
            return View(vuelo);
        }

        //
        // GET: /Vuelo/Delete/5
 
        public ActionResult Delete(int id)
        {
            Vuelo vuelo = db.Vuelo.Find(id);
            return View(vuelo);
        }

        //
        // POST: /Vuelo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Vuelo vuelo = db.Vuelo.Find(id);
            db.Vuelo.Remove(vuelo);
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