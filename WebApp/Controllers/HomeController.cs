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
        // GET: Home
        public ActionResult Inicio()
        {
            TempData["Controlador"] = "Consorcio";
            TempData["Accion"] = "ListarConsorcio";
            Hardcodeo.HardcodeoDatos();
            return View();
        }


        public ActionResult Ingresar()
        {
            RedireccionUsuario_VM irA = new RedireccionUsuario_VM() { Accion = TempData["Accion"] as string, Controlador = TempData["Controlador"] as string };
            return View(irA);
        }

        [HttpPost]
        public ActionResult Ingresar(RedireccionUsuario_VM ingreso)
        {
            if (ingreso.Email != null && ingreso.Password != null)
            {
                bool existeM = HomeServicios.VerificaEmail(ingreso.Email);
                if (existeM)
                {
                    string password = HomeServicios.Encriptar(ingreso.Password);
                    bool existeP = HomeServicios.VerificaPassword(password);
                    if (existeP)
                    {
                        Session["Nombre"] = UsuarioServicios.BuscarNombre(ingreso.Email);
                        Session["IdUsuario"] = UsuarioServicios.BuscarIdUsuario(ingreso.Email);
                        return RedirectToAction(ingreso.Accion, ingreso.Controlador);
                    }
                    ViewBag.error = "Email y/o Contraseña inválidos";
                    return View(ingreso);
                }

                ViewBag.error = "Email y/o Contraseña inválidos";
                return View(ingreso);
            }

            ViewBag.error = "Debe ingresar Email y Password";
            return View(ingreso);
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