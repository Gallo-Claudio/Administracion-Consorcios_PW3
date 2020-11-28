using DataAccessLayer.Modelos;
using MvcSiteMapProvider;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class UnidadController : Controller
    {
        ConsorcioServicio consorcio;
        UnidadServicio unidad;

        public UnidadController()
        {
            ContextoEntities contexto = new ContextoEntities();
            consorcio = new ConsorcioServicio(contexto);
            unidad = new UnidadServicio(contexto);
        }

        public ActionResult ListarUnidades(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                Consorcio busquedaConsorcio = consorcio.Buscar(id);
                var node = SiteMaps.Current.CurrentNode;
                if (node != null && node.ParentNode != null)
                {
                    node.ParentNode.Title = "Consorcio \"" + busquedaConsorcio.Nombre + "\"";
                }

                ViewBag.idConsorcio = id;
                List<Unidad> listadoUnidades = unidad.ListarUnidades(id);
                return View(listadoUnidades);
            }
            else
            {
                TempData["Controlador"] = "Unidad";
                TempData["Accion"] = "Listarunidades";
                return RedirectToAction("Ingresar", "Home");
            }
        }


        public ActionResult AgregarUnidad(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                Consorcio busquedaConsorcio = consorcio.Buscar(id);
                var node = SiteMaps.Current.CurrentNode;
                if (node != null && node.ParentNode != null)
                {
                    node.ParentNode.ParentNode.Title = "Consorcio \"" + busquedaConsorcio.Nombre + "\"";
                }

                ViewData["Consorcio"] = busquedaConsorcio;
                return View();
            }
            else
            {
                TempData["Controlador"] = "Unidad";
                TempData["Accion"] = "AgregarUnidad";
                return RedirectToAction("Ingresar", "Home");
            }
        }

        [HttpPost]
        public ActionResult AgregarUnidad(Unidad nuevaUnidad, int? id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    unidad.AgregarUnidades(nuevaUnidad, Session["IdUsuario"]);
                }
                catch
                {
                    TempData["error"] = "true";
                }
            }
            else
            {
                Consorcio busquedaConsorcio = consorcio.Buscar(nuevaUnidad.IdConsorcio);
                var node = SiteMaps.Current.CurrentNode;
                if (node != null && node.ParentNode != null)
                {
                    node.ParentNode.ParentNode.Title = "Consorcio \"" + busquedaConsorcio.Nombre + "\"";
                }

                ViewData["Consorcio"] = busquedaConsorcio;
                return View(nuevaUnidad);
            }

            List<string> definiciones = new List<string>() { "La unidad", nuevaUnidad.Nombre, "creado" };
            TempData["definiciones"] = definiciones;

            switch (id)
            {
                case 1:
                    if (TempData["error"] == "true")
                    {
                        Consorcio busquedaConsorcio = consorcio.Buscar(nuevaUnidad.IdConsorcio);
                        var node = SiteMaps.Current.CurrentNode;
                        if (node != null && node.ParentNode != null)
                        {
                            node.ParentNode.ParentNode.Title = "Consorcio \"" + busquedaConsorcio.Nombre + "\"";
                        }

                        ViewData["Consorcio"] = busquedaConsorcio;
                        return View(nuevaUnidad);
                    }
                    return RedirectToAction("AgregarUnidad/" + nuevaUnidad.IdConsorcio);

                default:
                    string url = "/unidad/ListarUnidades/" + nuevaUnidad.IdConsorcio;
                    return Redirect(url);
            }
        }

        public ActionResult ModificarUnidad(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                Unidad unidadFuncional = unidad.Buscar(id);

                Consorcio busquedaConsorcio = consorcio.Buscar(unidadFuncional.IdConsorcio);
                var node = SiteMaps.Current.CurrentNode;
                if (node != null && node.ParentNode != null)
                {
                    node.ParentNode.ParentNode.Title = "Consorcio \"" + busquedaConsorcio.Nombre + "\"";
                }

                ViewData["Consorcio"] = busquedaConsorcio;

                return View(unidadFuncional);
            }
            else
            {
                TempData["Controlador"] = "Unidad";
                TempData["Accion"] = "ModificarUnidad";
                return RedirectToAction("Ingresar", "Home");
            }
        }


        [HttpPost]
        public ActionResult ModificarUnidad(Unidad unidadModificado)
        {
            if (ModelState.IsValid)
            {
                List<string> definiciones = new List<string>() { "La unidad", unidadModificado.Nombre, "modificado" };
                try
                {
                    unidad.ModificarUnidad(unidadModificado);
                    TempData["definiciones"] = definiciones;
                    return Redirect("/unidad/ListarUnidades/" + unidadModificado.IdConsorcio);
                }
                catch
                {
                    TempData["error"] = "true";
                    TempData["definiciones"] = definiciones;

                    Consorcio busquedaConsorcio = consorcio.Buscar(unidadModificado.IdConsorcio);
                    var node = SiteMaps.Current.CurrentNode;
                    if (node != null && node.ParentNode != null)
                    {
                        node.ParentNode.ParentNode.Title = "Consorcio \"" + busquedaConsorcio.Nombre + "\"";
                    }

                    ViewData["Consorcio"] = busquedaConsorcio;
                    return View(unidadModificado);
                }
            }
            else
            {
                Consorcio busquedaConsorcio = consorcio.Buscar(unidadModificado.IdConsorcio);
                var node = SiteMaps.Current.CurrentNode;
                if (node != null && node.ParentNode != null)
                {
                    node.ParentNode.ParentNode.Title = "Consorcio \"" + busquedaConsorcio.Nombre + "\"";
                }

                ViewData["Consorcio"] = busquedaConsorcio;
                return View(unidadModificado);
            }
        }

        public ActionResult EliminarUnidad(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                Unidad unidadAEliminar = unidad.Buscar(id);

                var node = SiteMaps.Current.CurrentNode;
                if (node != null && node.ParentNode != null)
                {
                    node.ParentNode.Title = "Consorcio \"" + unidadAEliminar.Nombre + "\"";
                }

                Consorcio consorcioBuscado = consorcio.Buscar(unidadAEliminar.IdConsorcio);
                ViewBag.NombreConsorcio = consorcioBuscado.Nombre;
                return View(unidadAEliminar);
            }
            else
            {
                TempData["Controlador"] = "Unidad";
                TempData["Accion"] = "EliminarUnidad";
                return RedirectToAction("Ingresar", "Home");
            }
        }

        [HttpPost]
        public ActionResult DarDeBajaUnidad(int id)
        {
            string url = "/unidad/ListarUnidades/" + unidad.Buscar(id).IdConsorcio;
            unidad.Eliminar(id);
            return Redirect(url);
        }
    }
}