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

        public ExpensaController()
        {
            ContextoEntities contexto = new ContextoEntities();
            consorcio = new ConsorcioServicio(contexto);
            unidad = new UnidadServicio(contexto);
            expensa = new ExpensasServicio();
        }

        // GET: E
        public ActionResult ListarExpensa(int id)
        {
            string nombreConsorcio = consorcio.BuscarConsorcio(id).Nombre;
            var node = SiteMaps.Current.CurrentNode;
            if (node != null && node.ParentNode != null)
            {
                node.ParentNode.Title = "Consorcio \"" + nombreConsorcio + "\"";
            }

            List<sp_Expensas_Result> expensas = expensa.GetExpensas(id);

            List<sp_Expensas_Result> expensaListado = expensa.DeterminaMesActual(expensas);

            ViewData["CantidadUnidades"] = unidad.ListarUnidades(id).Count;
            ViewData["nombreConsorcio"] = nombreConsorcio;
            return View(expensas);
        }
    }
}