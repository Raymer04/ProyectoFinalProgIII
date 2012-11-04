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
    public class AeropuertoController : Controller
    {
        private LineaAereaDB db = new LineaAereaDB();

        //
        // GET: /Aeropuerto/

        public ViewResult Index()
        {
            return View(db.Aeropuerto.ToList());
        }

        //
        // GET: /Aeropuerto/Details/5

        public ViewResult Details(int id)
        {
            Aeropuerto aeropuerto = db.Aeropuerto.Find(id);
            return View(aeropuerto);
        }

        //
        // GET: /Aeropuerto/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Aeropuerto/Create

        [HttpPost]
        public ActionResult Create(Aeropuerto aeropuerto)
        {
            if (ModelState.IsValid)
            {
                db.Aeropuerto.Add(aeropuerto);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(aeropuerto);
        }
        
        //
        // GET: /Aeropuerto/Edit/5
 
        public ActionResult Edit(int id)
        {
            Aeropuerto aeropuerto = db.Aeropuerto.Find(id);
            return View(aeropuerto);
        }

        //
        // POST: /Aeropuerto/Edit/5

        [HttpPost]
        public ActionResult Edit(Aeropuerto aeropuerto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aeropuerto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aeropuerto);
        }

        //
        // GET: /Aeropuerto/Delete/5
 
        public ActionResult Delete(int id)
        {
            Aeropuerto aeropuerto = db.Aeropuerto.Find(id);
            return View(aeropuerto);
        }

        //
        // POST: /Aeropuerto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Aeropuerto aeropuerto = db.Aeropuerto.Find(id);
            db.Aeropuerto.Remove(aeropuerto);
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