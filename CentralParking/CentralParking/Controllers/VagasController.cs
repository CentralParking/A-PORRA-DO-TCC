using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CentralParking.Models;

namespace CentralParking.Controllers
{
    public class VagasController : Controller
    {
        private CentralParkingEntities db = new CentralParkingEntities();

        // GET: Vagas
        public ActionResult Index()
        {
            var vagas = db.Vagas.Include(v => v.Locador);
            return View(vagas.ToList());
        }

        // GET: Vagas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vagas vagas = db.Vagas.Find(id);
            if (vagas == null)
            {
                return HttpNotFound();
            }
            return View(vagas);
        }

        // GET: Vagas/Create
        public ActionResult Create()
        {
            ViewBag.CPF = new SelectList(db.Locador, "CPF", "Nome_Dono");
            return View();
        }

        // POST: Vagas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Vagas,CPF,Status,Cidade,Bairro,Rua,Numero,CEP")] Vagas vagas)
        {
            if (ModelState.IsValid)
            {
                db.Vagas.Add(vagas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CPF = new SelectList(db.Locador, "CPF", "Nome_Dono", vagas.CPF);
            return View(vagas);
        }

        // GET: Vagas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vagas vagas = db.Vagas.Find(id);
            if (vagas == null)
            {
                return HttpNotFound();
            }
            ViewBag.CPF = new SelectList(db.Locador, "CPF", "Nome_Dono", vagas.CPF);
            return View(vagas);
        }

        // POST: Vagas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Vagas,CPF,Status,Cidade,Bairro,Rua,Numero,CEP")] Vagas vagas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vagas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CPF = new SelectList(db.Locador, "CPF", "Nome_Dono", vagas.CPF);
            return View(vagas);
        }

        // GET: Vagas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vagas vagas = db.Vagas.Find(id);
            if (vagas == null)
            {
                return HttpNotFound();
            }
            return View(vagas);
        }

        // POST: Vagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vagas vagas = db.Vagas.Find(id);
            db.Vagas.Remove(vagas);
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
