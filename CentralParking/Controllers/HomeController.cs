using CentralParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentralParking.Controllers
{
    public class HomeController : Controller
    {
        CentralParkingEntities db = new CentralParkingEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Erro
        public ActionResult Erro()
        {
            return View();
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(locador user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new CentralParkingEntities())
                {
                    var v = db.locadors1.Where(a => a.email.Equals(user.email) && a.senha.Equals(user.senha)).FirstOrDefault();
                    if(v != null)
                    { 
                        if(v.Tipo.Equals("A"))
                        {
                            Session["NomeUsuárioLogado"] = v.Nome_Dono.ToString();

                            return RedirectToAction("Administrar", "Adm");
                        }
                        if (v.Tipo.Equals("u") || v.Tipo.Equals(""))
                        {
                            Session["NomeUsuárioLogado"] = v.Nome_Dono.ToString();
                            return RedirectToAction("Perfil", "Locadors");
                        }
                        else
                        {
                            return View();
                        }
                    }
                }
            }
            return View(user);
        }
    }
}