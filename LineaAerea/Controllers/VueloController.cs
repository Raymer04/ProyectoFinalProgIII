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
            ViewBag.ProcedenciaID = new SelectList(db.Aeropuerto, "Id", "Nombre");
            ViewBag.DestinoID = new SelectList(db.Aeropuerto, "Id", "Nombre");
            ViewBag.AvionID = new SelectList(db.Avion, "Id", "Marca");
            return View();
        } 

        //
        // POST: /Vuelo/Create

        [HttpPost]
        public ActionResult Create(Vuelo vuelo, String hora)
        {
            DateTime fechaHoy=DateTime.Now.Date;
            String[] hp=hora.Split(':');

            List<Vuelo> lista = db.Vuelo.ToList();
            String[] cp=null;
            String[] ce =null;
            int cont=1;
            foreach (Vuelo v in lista)
            {
                cp = v.HoraSalida.Split(':');
                ce = v.HoraSalida.Split(' ');
                int hor = Convert.ToInt32(hp[0]);
                DateTime horv = Convert.ToDateTime(ce[0]);
                if (v.AvionID == vuelo.AvionID && v.FechaSalida == fechaHoy)
                {
                    if (Convert.ToInt32(cp[0]) >= hor && Convert.ToInt32(cp[0]) <= horv.AddHours(v.Duracion).Hour)
                    {
                        cont++;
                    }
                }

            }

            if (db.Vuelo.Count(v => v.AvionID == vuelo.AvionID && v.FechaSalida == fechaHoy) >= 3){
                 ModelState.AddModelError("", "No se pudo crear mas de tres vuelos de un mismo avion en un mismo dia");
               
            }


            else if (cont >= 2)
            {
                ModelState.AddModelError("", "No se pudo crear mas de un vuelo en un mismo dia en el mismo horario");
            }

            else
            {
                vuelo.HoraSalida = hora;
                db.Vuelo.Add(vuelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProcedenciaID = new SelectList(db.Aeropuerto, "Id", "Nombre", vuelo.ProcedenciaID);
            ViewBag.DestinoID = new SelectList(db.Aeropuerto, "Id", "Nombre", vuelo.DestinoID);
            ViewBag.AvionID = new SelectList(db.Avion, "Id", "Marca", vuelo.AvionID);
            return View(vuelo);
        }
        
        
        //
        // GET: /Vuelo/Edit/5
 
        public ActionResult Edit(int id)
        {
            Vuelo vuelo = db.Vuelo.Find(id);
            ViewBag.ProcedenciaID = new SelectList(db.Aeropuerto, "Id", "Nombre", vuelo.ProcedenciaID);
            ViewBag.DestinoID = new SelectList(db.Aeropuerto, "Id", "Nombre", vuelo.DestinoID);
            ViewBag.AvionID = new SelectList(db.Avion, "Id", "Marca", vuelo.AvionID);
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
            ViewBag.AvionID = new SelectList(db.Avion, "Id", "Marca", vuelo.AvionID);
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