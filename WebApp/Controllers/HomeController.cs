using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos;
using Entidades;
using Servicios;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Inicio()
        //{
        //    Hardcodeo.HardcodeoDatos();
        //    return RedirectToAction("ListarConsorcio", "Consorcio");
        //}


        // GET: Home
        public ActionResult Inicio()
        {
            Hardcodeo.HardcodeoDatos();
            return View();
        }

        public ActionResult Ingresar()
        {
            return View();
        }

        public ActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrarse(Usuario nuevoUsuario)
        {
            bool existe = HomeServicios.VerificaEmail(nuevoUsuario.Email);

            if (existe)
            {
                ViewBag.error = "El mail ingresado ya existe";
                return View(nuevoUsuario);
            }
            else
            {
                HomeServicios.NuevoUsuario(nuevoUsuario);
                return RedirectToAction("Ingresar");
            }
        }
    }
}