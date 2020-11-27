using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Modelos;
using MvcSiteMapProvider;
using Servicios;

namespace WebApp.Controllers
{
    public class ConsorcioController : Controller
    {

        ConsorcioServicio consorcio;
        ProvinciaServicio provincia;
        UnidadServicio unidad;
        GastoServicio gasto;

        public ConsorcioController()
        {
            ContextoEntities contexto = new ContextoEntities();
            consorcio = new ConsorcioServicio(contexto);
            provincia = new ProvinciaServicio(contexto);
            unidad = new UnidadServicio(contexto);
            gasto = new GastoServicio(contexto);
        }

        public ActionResult ListarConsorcio()
        {
            if (Session["IdUsuario"] != null)
            {
                List<Consorcio> listadoConsorcio = consorcio.ListarConsorcios(Session["IdUsuario"]);
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
                List<Provincia> listadoProvincias = provincia.Listar();
                ViewData["listadoProvincias"] = listadoProvincias;
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
        public ActionResult AgregarConsorcio(Consorcio nuevoConsorcio, int? id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    consorcio.AgregarConsorcio(nuevoConsorcio, Session["IdUsuario"]);
                }
                catch
                {
                    TempData["error"] = "true";
                }
            }
            else
            {
                List<Provincia> listadoProvincias = provincia.Listar();
                ViewData["listadoProvincias"] = listadoProvincias;
                return View(nuevoConsorcio);
            }

            List<string> definiciones = new List<string>() { "El consorcio", nuevoConsorcio.Nombre };
            TempData["definiciones"] = definiciones;

            switch (id)
            {
                case 1:
                    return RedirectToAction("AgregarConsorcio");

                case 2:
                    if (TempData["error"] == null)
                    {
                        return Redirect("/Unidad/AgregarUnidad/" + nuevoConsorcio.IdConsorcio);
                    }
                    else
                    {
                        return RedirectToAction("AgregarConsorcio");
                    }

                default:
                    return RedirectToAction("ListarConsorcio");
            }
        }

        public ActionResult ModificarConsorcio(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                Consorcio busquedaConsorcioId = consorcio.Buscar(id);
                SiteMaps.Current.CurrentNode.Title = "Consorcio \"" + busquedaConsorcioId.Nombre + "\" > Editando Consorcio";

                List<Provincia> listadoProvincias = provincia.Listar();
                ViewData["listadoProvincias"] = listadoProvincias;


                ViewBag.cantidadUnidades = unidad.ListarUnidades(id).Count;

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
        public ActionResult ModificarConsorcio(Consorcio consorcioModificado)
        {
            if (ModelState.IsValid)
            {
                List<string> definiciones = new List<string>() { "El consorcio", consorcioModificado.Nombre };

                try
                {
                    consorcio.ModificarConsorcio(consorcioModificado);
                    return RedirectToAction("ListarConsorcio");
                }
                catch
                {
                    TempData["error"] = "true";

                    List<Provincia> listadoProvincias = provincia.Listar();
                    ViewData["listadoProvincias"] = listadoProvincias;

                    int id = consorcioModificado.IdConsorcio;
                    ViewBag.cantidadUnidades = unidad.ListarUnidades(id).Count;

                    return View(consorcioModificado);
                }

            }
            else
            {
                List<Provincia> listadoProvincias = provincia.Listar();
                ViewData["listadoProvincias"] = listadoProvincias;

                int id = consorcioModificado.IdConsorcio;
                ViewBag.cantidadUnidades = unidad.ListarUnidades(id).Count;

                return View(consorcioModificado);
            }
        }

        public ActionResult EliminarConsorcio(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                Consorcio consorcioAEliminar = consorcio.Buscar(id);

                var node = SiteMaps.Current.CurrentNode;
                if (node != null && node.ParentNode != null)
                {
                    node.ParentNode.Title = "Consorcio \"" + consorcioAEliminar.Nombre + "\"";
                }

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
        public ActionResult DarDeBajaConsorcio(int id)
        {
            gasto.EliminarGastosDeConsorcio(id);
            unidad.EliminarUnidadesDeConsorcio(id);
            consorcio.Eliminar(id);
            return RedirectToAction("ListarConsorcio");
        }
    }
}