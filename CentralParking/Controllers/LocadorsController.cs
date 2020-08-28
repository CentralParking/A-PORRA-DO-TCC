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
    public class locadorsController : Controller
    {
        CentralParkingEntities db = new CentralParkingEntities();

        // GET: locadors
        public ActionResult ListaDeUsuarios()
        {
            return View(db.locadors1.ToList());
        }

        // GET: locadors/Details/5
        public ActionResult Perfil(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            locador locador = db.locadors1.Find(id);
            if (locador == null)
            {
                return HttpNotFound();
            }
            return View(locador);
        }

        // GET: locadors/Create
        public ActionResult Cadastro()
        {
            List<String> locoulocaouad = new List<string>();
            locoulocaouad.Add("u");
            locoulocaouad.Add("");
            ViewBag.status = locoulocaouad;
            return View();
        }

        // POST: locadors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro([Bind(Include = "ID_Dono,Nome_Dono,Conta_Corrente,CPF,email,usuario,senha,Tipo")] locador locador)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.locadors1.Add(locador);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Home");
                }
            }
            catch
            {
                return RedirectToAction("Cadastro");
            }


            return View(locador);
        }

        // GET: locadors/Edit/5
        public ActionResult Editar(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            locador locador = db.locadors1.Find(id);
            if (locador == null)
            {
                return HttpNotFound();
            }
            return View(locador);
        }

        // POST: locadors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "ID_Dono,Nome_Dono,Conta_Corrente,CPF,email,usuario,senha,Tipo")] locador locador)
        {
            if (ModelState.IsValid)
            {

                db.Entry(locador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Perfil");
            }
            return View(locador);
        }

        // GET: locadors/Delete/5
        public ActionResult Deletar(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            locador locador = db.locadors1.Find(id);
            if (locador == null)
            {
                return HttpNotFound();
            }
            return View(locador);
        }

        // POST: locadors/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            locador locador = db.locadors1.Find(id);
            db.locadors1.Remove(locador);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
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
