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

        public ActionResult Index()
        {
            if (Session["usuario"] != null)
            {
                var vuelo = db.Vuelo.Include(v => v.Procedencia).Include(v => v.Destino).Include(v => v.Avion);
                return View(vuelo.ToList());
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Usuarios");
            }
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
            ViewBag.AvionID = new SelectList(db.Avion, "Id", "Modelo");
            return View();
        } 

        //
        // POST: /Vuelo/Create

        [HttpPost]
        public ActionResult Create(Vuelo vuelo)
        {
            if (db.Vuelo.Count(v => v.AvionID== vuelo.AvionID && v.Salida == vuelo.Salida && v.Llegada==vuelo.Llegada) < 2)
            {
                db.Vuelo.Add(vuelo);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else if (db.Vuelo.Count(v => v.AvionID == vuelo.AvionID) < 3)
            {
                db.Vuelo.Add(vuelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                ModelState.AddModelError("", "No se pudo crear este vuelo");
            }
            ViewBag.ProcedenciaID = new SelectList(db.Aeropuerto, "Id", "Lugar", vuelo.ProcedenciaID);
            ViewBag.DestinoID = new SelectList(db.Aeropuerto, "Id", "Lugar", vuelo.DestinoID);
            ViewBag.AvionID = new SelectList(db.Avion, "Id", "Modelo", vuelo.AvionID);
            return View(vuelo);
        }
        
        //
        // GET: /Vuelo/Edit/5
 
        public ActionResult Edit(int id)
        {
            Vuelo vuelo = db.Vuelo.Find(id);
            ViewBag.ProcedenciaID = new SelectList(db.Aeropuerto, "Id", "Lugar", vuelo.ProcedenciaID);
            ViewBag.DestinoID = new SelectList(db.Aeropuerto, "Id", "Lugar", vuelo.DestinoID);
            ViewBag.AvionID = new SelectList(db.Avion, "Id", "Modelo", vuelo.AvionID);
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
            ViewBag.ProcedenciaID = new SelectList(db.Aeropuerto, "Id", "Lugar", vuelo.ProcedenciaID);
            ViewBag.DestinoID = new SelectList(db.Aeropuerto, "Id", "Lugar", vuelo.DestinoID);
            ViewBag.AvionID = new SelectList(db.Avion, "Id", "Modelo", vuelo.AvionID);
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