using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CentralParking.Models;

namespace CentralParking.Controllers
{
    public class LocadorsController : Controller
    {
        private CentralParkingEntities db = new CentralParkingEntities();

        // GET: Locadors
        public ActionResult Index()
        {
            return View(db.Locador.ToList());
        }

        // GET: Locadors/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locador locador = db.Locador.Find(id);
            if (locador == null)
            {
                return HttpNotFound();
            }
            return View(locador);
        }

        // GET: Locadors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locadors/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Dono,Nome_Dono,CPF,email,usuario,senha,Tipo")] Locador locador)
        {
            if (ModelState.IsValid)
            {
                db.Locador.Add(locador);
                try
                {
                    db.SaveChanges();
                } catch (DbEntityValidationException e)
                {
                    foreach(var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach(var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                        }
                        
                    }
                    throw;
                }
                return RedirectToAction("Index");
            }

            return View(locador);
        }

        // GET: Locadors/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locador locador = db.Locador.Find(id);
            if (locador == null)
            {
                return HttpNotFound();
            }
            return View(locador);
        }

        // POST: Locadors/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Dono,Nome_Dono,CPF,email,usuario,senha,Tipo")] Locador locador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locador);
        }

        // GET: Locadors/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locador locador = db.Locador.Find(id);
            if (locador == null)
            {
                return HttpNotFound();
            }
            return View(locador);
        }

        // POST: Locadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Locador locador = db.Locador.Find(id);
            db.Locador.Remove(locador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
