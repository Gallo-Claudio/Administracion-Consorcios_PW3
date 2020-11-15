using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DataAccessLayer.Modelos;
using MvcSiteMapProvider;
using Servicios;

namespace WebApp.Controllers
{
    public class GastoController : Controller
    {
        GastoServicio gasto;

        public GastoController()
        {
            ContextoEntities contexto = new ContextoEntities();
            gasto = new GastoServicio(contexto);
        }

        // GET: Gasto
        public ActionResult ListarGasto(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                List<Gasto> listadoGasto = gasto.ListarGastos(id);
                return View(listadoGasto);
            }
            else
            {
                TempData["Controlador"] = "Gasto";
                TempData["Accion"] = "ListarGastos";
                return RedirectToAction("Ingresar", "Home");
            }
        }

        public ActionResult AgregarGasto()
        {
            if (Session["IdUsuario"] != null)
            {
                return View();
            }
            else
            {
                TempData["Controlador"] = "Gasto";
                TempData["Accion"] = "AgregarGasto";
                return RedirectToAction("Ingresar", "Home");
            }
        }

        [HttpPost]
        public ActionResult AgregarGasto(Gasto nuevoGasto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    gasto.AgregarGasto(nuevoGasto, Session["IdUsuario"]);
                    TempData["exito"] = "Se guardo el registro";
                    return RedirectToAction("ListarGasto");
                }
                catch
                {
                    TempData["error"] = "No se pudo guardar el registro";
                    return RedirectToAction("AgregarGasto");
                }

            }
            else
            {
                return View(nuevoGasto);
            }
        }

        public ActionResult ModificarGasto(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                Gasto busqueadaGastoId = gasto.BuscarGasto(id);
                return View();
            }
            else
            {
                TempData["Controlador"] = "Gasto";
                TempData["Accion"] = "ModificarGasto";
                return RedirectToAction("Ingresar", "Home");
            }
        }

        [HttpPost]
        public ActionResult ModificarGasto(Gasto gastoModificado)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    gasto.ModificarGasto(gastoModificado);
                }
                catch
                {
                    TempData["error"] = "No se pudo modificar el registro";
                    int id = gastoModificado.IdGasto;
                    return View("ModificarGasto", gastoModificado);
                }

            }
            else
            {
                int id = gastoModificado.IdGasto;
                return View("ModificarGasto", gastoModificado);
            }

            return RedirectToAction("ListarGasto");
        }
    }
}
