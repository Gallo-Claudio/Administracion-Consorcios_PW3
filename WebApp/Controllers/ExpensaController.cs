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

        public ActionResult ListarExpensa(int id)
        {
            Consorcio Consorcio = consorcio.Buscar(id);
            var node = SiteMaps.Current.CurrentNode;
            if (node != null && node.ParentNode != null)
            {
                node.ParentNode.Title = "Consorcio \"" + Consorcio.Nombre + "\"";
            }

            List<sp_Expensas_Result> expensas = expensa.GetExpensas(id);

            List<sp_Expensas_Result> expensaListado = expensa.DeterminaMesActual(expensas);

            ViewData["CantidadUnidades"] = unidad.ListarUnidades(id).Count;
            ViewData["Consorcio"] = Consorcio;
            return View(expensas);
        }
    }
}