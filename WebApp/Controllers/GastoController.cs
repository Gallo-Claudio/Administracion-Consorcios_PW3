using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
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
        UsuarioServicios usuario;

        public GastoController()
        {
            ContextoEntities contexto = new ContextoEntities();
            gasto = new GastoServicio(contexto);
            consorcio = new ConsorcioServicio(contexto);
            tipoGasto = new TipoGastoServicio(contexto);
            usuario = new UsuarioServicios(contexto);
        }

        public ActionResult VerGastos(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                bool autentica = usuario.AutenticacionDatosPorUsuario(id, Session["IdUsuario"]);

                if (autentica)
                {
                    Consorcio busquedaConsorcio = consorcio.Buscar(id);
                    var node = SiteMaps.Current.CurrentNode;
                    if (node != null && node.ParentNode != null)
                    {
                        node.ParentNode.Title = "Consorcio \"" + busquedaConsorcio.Nombre + "\"";
                    }

                    ViewData["consorcio"] = busquedaConsorcio;
                    List<Gasto> listadoGasto = gasto.ListarGastos(id);
                    return View(listadoGasto);
                }
                else
                {
                    @ViewBag.Title = "Acceso de datos indebidos";
                    ViewBag.DescripcionError = "Los datos solicitados no son de su propiedad";
                    return View("~/views/error/PaginaError.cshtml");
                }
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
                bool autentica = usuario.AutenticacionDatosPorUsuario(id, Session["IdUsuario"]);

                if (autentica)
                {
                    Consorcio busquedaConsorcio = consorcio.Buscar(id);
                    var node = SiteMaps.Current.CurrentNode;
                    if (node != null && node.ParentNode != null)
                    {
                        node.ParentNode.ParentNode.Title = "Consorcio \"" + busquedaConsorcio.Nombre + "\"";
                    }

                    List<TipoGasto> listaTipoGasto = tipoGasto.Listar();

                    ViewData["consorcio"] = busquedaConsorcio;
                    ViewData["listadoTipoGasto"] = listaTipoGasto;
                    return View();
                }
                else
                {
                    @ViewBag.Title = "Acceso de datos indebidos";
                    ViewBag.DescripcionError = "Los datos solicitados no son de su propiedad";
                    return View("~/views/error/PaginaError.cshtml");
                }
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
            if (ModelState.IsValid)
            {
                List<string> definiciones = new List<string>() { "El gasto", nuevoGasto.Nombre, "creado" };
                TempData["definiciones"] = definiciones;
                try
                {
                    string nombreArchivoConFecha = gasto.NombreArchivoASubir(ArchivoComprobante);
                    nuevoGasto.ArchivoComprobante = nombreArchivoConFecha;

                    gasto.AgregarGasto(nuevoGasto, Session["IdUsuario"]);
                    if (ArchivoComprobante.ContentLength > 0)
                    {
                        string path = Path.Combine(Server.MapPath("~/Gastos/"), nombreArchivoConFecha);
                        ArchivoComprobante.SaveAs(path);
                    }

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
                    TempData["error"] = "true";
                    ViewData["listadoTipoGasto"] = tipoGasto.Listar();

                    Consorcio busquedaConsorcio = consorcio.Buscar(nuevoGasto.IdConsorcio);
                    var node = SiteMaps.Current.CurrentNode;
                    if (node != null && node.ParentNode != null)
                    {
                        node.ParentNode.ParentNode.Title = "Consorcio \"" + busquedaConsorcio.Nombre + "\"";
                    }

                    ViewData["consorcio"] = busquedaConsorcio;
                    return View(nuevoGasto);
                }

            }
            else
            {
                Consorcio busquedaConsorcio = consorcio.Buscar(nuevoGasto.IdConsorcio);
                var node = SiteMaps.Current.CurrentNode;
                if (node != null && node.ParentNode != null)
                {
                    node.ParentNode.ParentNode.Title = "Consorcio \"" + busquedaConsorcio.Nombre + "\"";
                }

                ViewData["consorcio"] = busquedaConsorcio;
                ViewData["listadoTipoGasto"] = tipoGasto.Listar();
                return View(nuevoGasto);
            }
        }

        public ActionResult ModificarGasto(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                Gasto busqueadaGasto = gasto.Buscar(id);
                Consorcio consorcioResultado = busqueadaGasto.Consorcio;

                bool autentica = usuario.AutenticacionDatosPorUsuario(consorcioResultado.IdConsorcio, Session["IdUsuario"]);

                if (autentica)
                {
                    List<string> mensaje = new List<string>() { consorcioResultado.Nombre, "" + consorcioResultado.IdConsorcio, "Gastos", "/Gasto/VerGastos/", "> Editando Gasto" };
                    ViewData["breadcumb"] = mensaje;

                    List<TipoGasto> listaTipoGasto = tipoGasto.Listar();
                    TempData["listadoTipoGasto"] = listaTipoGasto;
                    ViewData["consorcioNombre"] = consorcioResultado.Nombre;

                    ViewBag.nombreArchivo = Regex.Replace(busqueadaGasto.ArchivoComprobante, @"/Gastos/", "");
                    ViewBag.nombreGasto = busqueadaGasto.Nombre;
                    return View(busqueadaGasto);
                }
                else
                {
                    @ViewBag.Title = "Acceso de datos indebidos";
                    ViewBag.DescripcionError = "Los datos solicitados no son de su propiedad";
                    return View("~/views/error/PaginaError.cshtml");
                }
            }
            else
            {
                TempData["Controlador"] = "Gasto";
                TempData["Accion"] = "ModificarGasto";
                return RedirectToAction("Ingresar", "Home");
            }
        }

        [HttpPost]
        public ActionResult ModificarGasto(Gasto gastoModificado, HttpPostedFileBase archivo, string nombreDeGasto)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";
                if (archivo != null)
                {
                    string nombreArchivoConFecha = gasto.NombreArchivoASubir(archivo);
                    gastoModificado.ArchivoComprobante = "/Gastos/" + nombreArchivoConFecha;
                    fileName = nombreArchivoConFecha;
                }

                List<string> definiciones = new List<string>() { "El gasto", gastoModificado.Nombre, "modificado" };
                TempData["definiciones"] = definiciones;

                try
                {
                    gasto.ModificarGasto(gastoModificado);
                    if (archivo != null && archivo.ContentLength > 0)
                    {
                        var path = Path.Combine(Server.MapPath("~/Gastos/"), fileName);
                        archivo.SaveAs(path);
                    }

                    return RedirectToAction("VerGastos/" + gastoModificado.IdConsorcio);
                }
                catch
                {
                    TempData["error"] = "true";
                    Consorcio consorcioResultado = consorcio.Buscar(gastoModificado.IdConsorcio);
                    List<string> mensaje = new List<string>() { consorcioResultado.Nombre, "" + consorcioResultado.IdConsorcio, "Gastos", "/Gasto/VerGastos/", "> Editando Gasto" };
                    ViewData["breadcumb"] = mensaje;

                    List<TipoGasto> listaTipoGasto = tipoGasto.Listar();
                    TempData["listadoTipoGasto"] = listaTipoGasto;
                    ViewData["consorcioNombre"] = consorcioResultado.Nombre;

                    ViewBag.nombreGasto = nombreDeGasto;
                    ViewBag.nombreArchivo = Regex.Replace(gastoModificado.ArchivoComprobante, @"/Gastos/", "");
                    return View(gastoModificado);
                }
            }
            else
            {
                Consorcio consorcioResultado = consorcio.Buscar(gastoModificado.IdConsorcio);
                List<string> mensaje = new List<string>() { consorcioResultado.Nombre, "" + consorcioResultado.IdConsorcio, "Gastos", "/Gasto/VerGastos/", "> Editando Gasto" };
                ViewData["breadcumb"] = mensaje;

                List<TipoGasto> listaTipoGasto = tipoGasto.Listar();
                TempData["listadoTipoGasto"] = listaTipoGasto;
                ViewData["consorcioNombre"] = consorcioResultado.Nombre;

                ViewBag.nombreGasto = nombreDeGasto;
                ViewBag.nombreArchivo = Regex.Replace(gastoModificado.ArchivoComprobante, @"/Gastos/", "");
                return View(gastoModificado);
            }
        }

        public ActionResult EliminarGasto(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                Gasto busqueadaGastoId = gasto.Buscar(id);

                bool autentica = usuario.AutenticacionDatosPorUsuario(busqueadaGastoId.Consorcio.IdConsorcio, Session["IdUsuario"]);

                if (autentica)
                {
                    return View(busqueadaGastoId);
                }
                else
                {
                    @ViewBag.Title = "Acceso de datos indebidos";
                    ViewBag.DescripcionError = "Los datos solicitados no son de su propiedad";
                    return View("~/views/error/PaginaError.cshtml");
                }
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