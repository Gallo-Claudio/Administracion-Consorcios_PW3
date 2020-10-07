using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Inicio()
        {
            Hardcodeo.HardcodeoDatos();
            return RedirectToAction("ListarConsorcio", "Consorcio");
        }
    }
}