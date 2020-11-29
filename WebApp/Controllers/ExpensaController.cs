using DataAccessLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servicios;
using MvcSiteMapProvider;

namespace WebApp.Controllers
{
    public class ExpensaController : Controller
    {
        ExpensasServicio expensa;
        ConsorcioServicio consorcio;
        UnidadServicio unidad;
        UsuarioServicios usuario;

        public ExpensaController()
        {
            ContextoEntities contexto = new ContextoEntities();
            consorcio = new ConsorcioServicio(contexto);
            unidad = new UnidadServicio(contexto);
            expensa = new ExpensasServicio();
            usuario = new UsuarioServicios(contexto);
        }

        public ActionResult ListarExpensa(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                Consorcio Consorcio = consorcio.Buscar(id);

                bool autentica = usuario.AutenticacionDatosPorUsuario(Consorcio.IdConsorcio, Session["IdUsuario"]);

                if (autentica)
                {

                    var node = SiteMaps.Current.CurrentNode;
                    if (node != null && node.ParentNode != null)
                    {
                        node.ParentNode.Title = "Consorcio \"" + Consorcio.Nombre + "\"";
                    }

                    List<sp_Expensas_Result> expensas = expensa.GetExpensas(id);

                    List<sp_Expensas_Result> expensaListado = expensa.DeterminaMesActual(expensas);

                    ViewData["CantidadUnidades"] = unidad.ListarUnidades(id).Count;
                    ViewData["Consorcio"] = Consorcio;
                    return View(expensaListado);
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
                TempData["Controlador"] = "Expensa";
                TempData["Accion"] = "ListarExpensa";
                return RedirectToAction("Ingresar", "Home");
            }
        }
    }
}