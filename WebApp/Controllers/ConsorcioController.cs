using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Servicios;

namespace WebApp.Controllers
{
    public class ConsorcioController : Controller
    {
        // GET: Consorcio
        public ActionResult ListarConsorcio()
        {
            if (Session["IdUsuario"] != null)
            {
                List<Consorcio> listadoConsorcio = ConsorcioServicio.ListarConsorcios();
                return View(listadoConsorcio);
            }
            else
            {
                TempData["Controlador"] = "Consorcio";
                TempData["Accion"] = "ListarConsorcio";
                return RedirectToAction("Ingresar", "Home");
            }
        }

        public ActionResult AgregarConsorcio()
        {
            if (Session["IdUsuario"] != null)
            {
                List<Provincia> provincias = ProvinciaServicio.ListarProvincias();
                ViewData["listadoProvincias"] = provincias;
                return View();
            }
            else
            {
                TempData["Controlador"] = "Consorcio";
                TempData["Accion"] = "AgregarConsorcio";
                return RedirectToAction("Ingresar", "Home");
            }
        }

        [HttpPost]
        public ActionResult AgregarConsorcio(Entidades.Consorcio consorcio, int IdProvincia, int? id)
        {
            ConsorcioServicio.AgregarConsorcio(consorcio, IdProvincia);

            switch (id)
            {
                case 1:
                    return RedirectToAction("AgregarConsorcio");
                case 2:
                    return RedirectToAction("AgregarUnidad", "Unidad");  // ("Accion", "Controlador")
                default:
                    return RedirectToAction("ListarConsorcio");
            }
        }

        public ActionResult ModificarConsorcio(int id)
        {
            if (Session["IdUsuario"] != null)
            {
            Consorcio busquedaConsorcioId = ConsorcioServicio.BuscarConsorcio(id);

            List<Provincia> provincias = ProvinciaServicio.ListarProvincias();
            ViewData["listadoProvincias"] = provincias;

            int cantidadUnidades = UnidadServicio.ContarUnidades(id);
            ViewBag.cantidadUnidades = cantidadUnidades;

            return View(busquedaConsorcioId);
            }
            else
            {
                TempData["Controlador"] = "Consorcio";
                TempData["Accion"] = "ModificarConsorcio";
                return RedirectToAction("Ingresar", "Home");
            }
        }

        [HttpPost]
        public ActionResult ModificarConsorcio(Entidades.Consorcio consorcio, int IdProvincia)
        {
            ConsorcioServicio.ModificarConsorcio(consorcio, IdProvincia);
            return RedirectToAction("ListarConsorcio");
        }

        public ActionResult EliminarConsorcio(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                Consorcio consorcioAEliminar = ConsorcioServicio.BuscarConsorcio(id);
                return View(consorcioAEliminar);
            }
            else
            {
                TempData["Controlador"] = "Consorcio";
                TempData["Accion"] = "EliminarConsorcio";
                return RedirectToAction("Ingresar", "Home");
            }
        }

        [HttpPost]
        public ActionResult EliminarConsorcio(Consorcio consorcioEliminar)
        {
            ConsorcioServicio.EliminarGastos(consorcioEliminar);
            ConsorcioServicio.EliminarUnidades(consorcioEliminar);
            ConsorcioServicio.EliminarConsorcio(consorcioEliminar);
            return RedirectToAction("ListarConsorcio");
        }
    }
}