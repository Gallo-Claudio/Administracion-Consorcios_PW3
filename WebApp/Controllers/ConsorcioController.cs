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

        // GET: Consorcio
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
                List<Provincia> listadoProvincias = provincia.ListarProvincias();
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
                    TempData["error"] = "No se pudo guardar el registro";
                }

            }
            else
            {
                List<Provincia> listadoProvincias = provincia.ListarProvincias();
                ViewData["listadoProvincias"] = listadoProvincias;
                return View(nuevoConsorcio);
            }

            TempData["nombreConsorcio"] = nuevoConsorcio.Nombre;
            switch (id)
            {
                case 1:
                    return RedirectToAction("AgregarConsorcio");
                case 2:
                    if (TempData["error"] == null)
                    {
                        return RedirectToAction("AgregarUnidad", "Unidad");  // ("Accion", "Controlador")
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
                Consorcio busquedaConsorcioId = consorcio.BuscarConsorcio(id);
                SiteMaps.Current.CurrentNode.Title = "Consorcio \"" + busquedaConsorcioId.Nombre + "\" > Editando Consorcio";

                List<Provincia> listadoProvincias = provincia.ListarProvincias();
                ViewData["listadoProvincias"] = listadoProvincias;

                //int cantidadUnidades = UnidadServicio.ContarUnidades(id);
                //ViewBag.cantidadUnidades = cantidadUnidades;

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
                try
                {
                    consorcio.ModificarConsorcio(consorcioModificado);                    
                }
                catch
                {
                    TempData["error"] = "No se pudo modificar el registro";
                    int id = consorcio.BuscarIdConsorcio(consorcioModificado);
                    List<Provincia> listadoProvincias = provincia.ListarProvincias();
                    ViewData["listadoProvincias"] = listadoProvincias;

                    return View("ModificarConsorcio", consorcioModificado);
                }             
             
            }
            else
            {
                int id = consorcio.BuscarIdConsorcio(consorcioModificado);
                List<Provincia> listadoProvincias = provincia.ListarProvincias();
                ViewData["listadoProvincias"] = listadoProvincias;

                //int cantidadUnidades = UnidadServicio.ContarUnidades(id);
                //ViewBag.cantidadUnidades = cantidadUnidades;

                return View("ModificarConsorcio", consorcioModificado);
            }
            
            return RedirectToAction("ListarConsorcio");
        }

        public ActionResult EliminarConsorcio(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                Consorcio consorcioAEliminar = consorcio.BuscarConsorcio(id);

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
            consorcio.EliminarConsorcio(id);
            return RedirectToAction("ListarConsorcio");
        }
    }
}