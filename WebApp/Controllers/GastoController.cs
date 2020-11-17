using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Modelos;
using MvcSiteMapProvider;
using Servicios;

namespace WebApp.Controllers
{
    public class GastoController : Controller
    {
        GastoServicio gasto;
        ConsorcioServicio consorcio;
        TipoGastoServicio tipoGasto;

        public GastoController()
        {
            ContextoEntities contexto = new ContextoEntities();
            gasto = new GastoServicio(contexto);
            consorcio = new ConsorcioServicio(contexto);
            tipoGasto = new TipoGastoServicio(contexto);
        }

        // GET: Gasto
        public ActionResult VerGastos(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                ViewData["consorcio"] = consorcio.BuscarConsorcio(id);
                List<Gasto> listadoGasto = gasto.ListarGastos(id);
                return View(listadoGasto);
            }
            else
            {
                TempData["Controlador"] = "Gasto";
                TempData["Accion"] = "VerGastos/" + id;
                return RedirectToAction("Ingresar", "Home");
            }
        }

        public ActionResult AgregarGasto(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                Consorcio consorcioResultado = consorcio.BuscarConsorcio(id);
                List<TipoGasto> listaTipoGasto = tipoGasto.ListarTipoGastos();
                ViewData["consorcio"] = consorcioResultado;
                ViewData["consorcioNombre"] = consorcioResultado.Nombre;
                ViewData["consorcioId"] = consorcioResultado.IdConsorcio;
                ViewData["listadoTipoGasto"] = listaTipoGasto;
                return View();
            }
            else
            {
                TempData["Controlador"] = "Gasto";
                TempData["Accion"] = "AgregarGasto/" + id;
                return RedirectToAction("Ingresar", "Home");
            }
        }

        [HttpPost]
        public ActionResult AgregarGasto(Gasto nuevoGasto, HttpPostedFileBase ArchivoComprobante)
        {
            var consorcioId = Request["consorcioId"];
            Consorcio consorcioResultado = consorcio.BuscarConsorcio(Int32.Parse(consorcioId));
            TipoGasto tipoGastoResultado = tipoGasto.BuscarTipoGasto(nuevoGasto.TipoGasto.IdTipoGasto);
            nuevoGasto.Consorcio = consorcioResultado;
            nuevoGasto.TipoGasto = tipoGastoResultado;
            TempData["nombreGasto"] = nuevoGasto.Nombre;
            var fileName = Path.GetFileName(ArchivoComprobante.FileName);
            nuevoGasto.ArchivoComprobante = fileName;
            if (ModelState.IsValid)
            {
                try
                {
                    gasto.AgregarGasto(nuevoGasto, Session["IdUsuario"]);
                    TempData["exito"] = "Se guardo el registro";
                    if (ArchivoComprobante.ContentLength > 0)
                    {
                        var path = Path.Combine(Server.MapPath("~/Gastos/"), fileName);
                        ArchivoComprobante.SaveAs(path);
                    }
                    return RedirectToAction("verGastos/"+ consorcioId);
                }
                catch
                {
                    TempData["error"] = "No se pudo guardar el registro";
                    return RedirectToAction("agregargasto/" + consorcioId);
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

        public ActionResult EliminarGasto(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                Gasto busqueadaGastoId = gasto.BuscarGasto(id);

                var node = SiteMaps.Current.CurrentNode;
                if (node != null && node.ParentNode != null)
                {
                    node.ParentNode.Title = "Gasto \"" + busqueadaGastoId.Nombre + "\"";
                }

                return View(busqueadaGastoId);
            }
            else
            {
                TempData["Controlador"] = "Gasto";
                TempData["Accion"] = "EliminarGasto/" + id;
                return RedirectToAction("Ingresar", "Home");
            }
        }

        [HttpPost]
        public ActionResult DarDeBajaGasto(int id)
        {
            Gasto gastoResultado = gasto.BuscarGasto(id);
            gasto.EliminarGasto(id);
            //TODO eliminar archivo
            return RedirectToAction("VerGastos/" + gastoResultado.IdConsorcio);
        }


        public FileResult Download()
        {
            string filename = Request["file"];
            var FileVirtualPath = "~/Gastos/" + filename;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }
    }
}
