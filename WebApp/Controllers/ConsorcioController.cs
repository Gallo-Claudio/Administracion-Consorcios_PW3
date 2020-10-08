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
            List<Consorcio> listadoConsorcio = ConsorcioServicio.ListarConsorcios();
            return View(listadoConsorcio);
        }
        
        public ActionResult AgregarConsorcio()
        {
            List<Provincia> provincias = ProvinciaServicio.ListarProvincias();
            ViewData["listadoProvincias"] = provincias;
            return View();
        }

        [HttpPost]
        public ActionResult AgregarConsorcio(Entidades.Consorcio consorcio, int IdProvincia)
        {       
            ConsorcioServicio.AgregarConsorcio(consorcio, IdProvincia);
            List<Entidades.Consorcio> listadoConsorcio = ConsorcioServicio.ListarConsorcios();
            return RedirectToAction("ListarConsorcio", listadoConsorcio);
        }
    }
}