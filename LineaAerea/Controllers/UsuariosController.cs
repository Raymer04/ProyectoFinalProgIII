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
    public class UsuariosController : Controller
    {
        private LineaAereaDB db = new LineaAereaDB();

        //
        // GET: /Usuarios/

        public ViewResult Index()
        {
            return View(db.Usuario.ToList());
        }

        //
        // GET: /Usuarios/Details/5

        public ViewResult Details(int id)
        {
            Usuarios usuarios = db.Usuario.Find(id);
            return View(usuarios);
        }

        //
        // GET: /Usuarios/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Usuarios/Create

        [HttpPost]
        public ActionResult Create(Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("IniciarSesion");  
            }

            return View(usuarios);
        }
        
        //
        // GET: /Usuarios/Edit/5
 
        public ActionResult Edit(int id)
        {
            Usuarios usuarios = db.Usuario.Find(id);
            return View(usuarios);
        }

        //
        // POST: /Usuarios/Edit/5

        [HttpPost]
        public ActionResult Edit(Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuarios);
        }

        //
        // GET: /Usuarios/Delete/5
 
        public ActionResult Delete(int id)
        {
            Usuarios usuarios = db.Usuario.Find(id);
            return View(usuarios);
        }

        //
        // POST: /Usuarios/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Usuarios usuarios = db.Usuario.Find(id);
            db.Usuario.Remove(usuarios);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

          public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(LineaAerea.Models.Usuarios.IniciarSesion model, string returnUrl)
        {
            if (db.Usuario.Count(p => p.Usuario == model.Usuario && p.Password == model.Password) > 0)
            {
                Usuarios usuario = db.Usuario.Where(p => p.Usuario == model.Usuario && p.Password == model.Password).First();
                Session["usuario"] = usuario;
                Session["nombre"] = usuario.Nombre + " " + usuario.Apellido;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "");
            }
            return View(model);

        }

        public ActionResult Salir()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
 }
