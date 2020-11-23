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

        public ActionResult VerGastos(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                Consorcio consorcioResultado = consorcio.Buscar(id);
                ViewData["consorcioNombre"] = consorcioResultado.Nombre;
                ViewData["consorcioId"] = consorcioResultado.IdConsorcio;
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
                Consorcio consorcioResultado = consorcio.Buscar(id);
                List<TipoGasto> listaTipoGasto = tipoGasto.Listar();
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
        public ActionResult AgregarGasto(Gasto nuevoGasto, HttpPostedFileBase ArchivoComprobante, int? id)
        {
            var fileName = Path.GetFileName(ArchivoComprobante.FileName);
            nuevoGasto.ArchivoComprobante = fileName;
            if (ModelState.IsValid)
            {
                TempData["nombreGasto"] = nuevoGasto.Nombre;
                try
                {
                    gasto.AgregarGasto(nuevoGasto, Session["IdUsuario"]);
                    if (ArchivoComprobante.ContentLength > 0)
                    {
                        var path = Path.Combine(Server.MapPath("~/Gastos/"), fileName);
                        ArchivoComprobante.SaveAs(path);
                    }

                    TempData["exito"] = "Se guardo el registro";
                    if (id == 1)
                    {
                        return RedirectToAction("AgregarGasto/" + nuevoGasto.IdConsorcio);
                    }
                    else
                    {
                        return RedirectToAction("verGastos/" + nuevoGasto.IdConsorcio);
                    }

                }
                catch
                {
                    TempData["error"] = "No se pudo guardar el registro";
                    return RedirectToAction("AgregarGasto/" + nuevoGasto.IdConsorcio);
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
                Gasto busqueadaGasto = gasto.Buscar(id);
                Consorcio consorcioResultado = busqueadaGasto.Consorcio;
                List<TipoGasto> listaTipoGasto = tipoGasto.Listar();
                TempData["listadoTipoGasto"] = listaTipoGasto;
                TempData["consorcio"] = consorcioResultado;
                return View(busqueadaGasto);
            }
            else
            {
                TempData["Controlador"] = "Gasto";
                TempData["Accion"] = "ModificarGasto";
                return RedirectToAction("Ingresar", "Home");
            }

        }

        [HttpPost]
        public ActionResult ModificarGasto(Gasto gastoModificado, HttpPostedFileBase archivo)
        {
            if (ModelState.IsValid)
            {
                var fileName = "";
                if (archivo != null)
                {
                    fileName = Path.GetFileName(archivo.FileName);
                    gastoModificado.ArchivoComprobante = fileName;
                }
                try
                {
                    gasto.ModificarGasto(gastoModificado);
                    if (archivo != null && archivo.ContentLength > 0)
                    {
                        var path = Path.Combine(Server.MapPath("~/Gastos/"), fileName);
                        archivo.SaveAs(path);
                    }
                    TempData["modificado"] = "Se modifico el registro";
                    TempData["nombreGasto"] = gastoModificado.Nombre;
                    int idConsorcio = gasto.Buscar(gastoModificado.IdGasto).IdConsorcio;
                    return RedirectToAction("VerGastos/" + idConsorcio);
                }
                catch
                {
                    TempData["error"] = "No se pudo modificar el registro";
                    TempData["nombreGasto"] = gastoModificado.Nombre;
                    return RedirectToAction("ModificarGasto/" + gastoModificado.IdGasto);
                }
            }
            else
            {
                TempData["error"] = "La modificacion del registro no es valida";
                TempData["nombreGasto"] = gastoModificado.Nombre;
                return RedirectToAction("ModificarGasto/" + gastoModificado.IdGasto);
            }


        }

        public ActionResult EliminarGasto(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                Gasto busqueadaGastoId = gasto.Buscar(id);
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
            Gasto gastoResultado = gasto.Buscar(id);
            gasto.Eliminar(id);
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