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
    public class VueloController : Controller
    {

      
       
        
        private AgenciaDB db = new AgenciaDB();
        
        //
        // GET: /Vuelo/

        public ViewResult Index()
        {
            return View(db.Vueloes.ToList());
        }

        //
        // GET: /Vuelo/Details/5

        public ViewResult Details(int id)
        {
            Vuelo vuelo = db.Vueloes.Find(id);
            return View(vuelo);
        }

        //
        // GET: /Vuelo/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Vuelo/Create

        [HttpPost]
        public ActionResult Create(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                db.Vueloes.Add(vuelo);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(vuelo);
        }
        
        //
        // GET: /Vuelo/Edit/5
 
        public ActionResult Edit(int id)
        {
            Vuelo vuelo = db.Vueloes.Find(id);
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
            return View(vuelo);
        }

        //
        // GET: /Vuelo/Delete/5
         
        public ActionResult Delete(int id)
        {
            Vuelo vuelo = db.Vueloes.Find(id);
            return View(vuelo);
        }

        public ActionResult BuscarVuelo(int id)
        {
            ServicioWeb.ServicioDeComunicacion a = new ServicioWeb.ServicioDeComunicacion();
            DataTable tabla;
            DateTime fecha = new DateTime().Date;
            tabla = a.VuelosDisponibles("", "", fecha);
 
            return View(tabla);
        }

        //
        // POST: /Vuelo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Vuelo vuelo = db.Vueloes.Find(id);
            db.Vueloes.Remove(vuelo);
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