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
    }
}