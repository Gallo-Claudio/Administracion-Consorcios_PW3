using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Modelos;
using Datos;
using Entidades;
using Servicios;

namespace WebApp.Controllers //Test1234!
{
    public class HomeController : Controller
    {
        UsuarioServicios usuario;

        public HomeController()
        {
            ContextoEntities contexto = new ContextoEntities();
            usuario = new UsuarioServicios(contexto);
        }

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
                bool existeM = usuario.VerificaEmail(ingreso.Email);
                if (existeM)
                {
                    string password = usuario.Encriptar(ingreso.Password);
                    bool existeP = usuario.VerificaPassword(password, ingreso.Email);
                    if (existeP)
                    {
                        Session["Nombre"] = usuario.BuscarNombre(ingreso.Email);
                        Session["IdUsuario"] = usuario.BuscarIdUsuario(ingreso.Email);
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
        public ActionResult Registrarse(Usuario_VM nuevoUsuario)
        {
            if (ModelState.IsValid)
            {
                bool existe = usuario.VerificaEmail(nuevoUsuario.Email);

                if (existe)
                {
                    ViewBag.error = "El mail ingresado ya existe";
                    return View(nuevoUsuario);
                }
                else
                {
                    usuario.NuevoUsuario(nuevoUsuario);
                    return RedirectToAction("Ingresar");
                }
            }
            else
            {
                return View(nuevoUsuario);
            }
        }

        public ActionResult Salir()
        {
            Session.Abandon();
            return RedirectToAction("Inicio");
        }
    }
}