using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentralParking.Controllers
{
    public class AdmController : Controller
    {
        // GET: Adm
        public ActionResult Administrar()
        {
            return View();
        }
        
        // GET: Lista
        public ActionResult ListarLocador()
        {
            return View();
        }

    }
}