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
        public ActionResult AgregarConsorcio(Entidades.Consorcio consorcio, int IdProvincia, int? id)
        {       
            ConsorcioServicio.AgregarConsorcio(consorcio, IdProvincia);

            switch (id)
            {
                case 1:
                    return RedirectToAction("AgregarConsorcio");
                case 2:
                    return RedirectToAction("AgregarUnidad", "Unidad");  // ("Accion", "Controlador") 
                default:                    
                    return RedirectToAction("ListarConsorcio");
            }            
        }

        public ActionResult ModificarConsorcio(int id)
        {
            Consorcio busquedaConsorcioId = ConsorcioServicio.BuscarConsorcio(id);

            List<Provincia> provincias = ProvinciaServicio.ListarProvincias();
            ViewData["listadoProvincias"] = provincias;

            int cantidadUnidades = UnidadServicio.ContarUnidades(id);
            ViewBag.cantidadUnidades = cantidadUnidades;

            return View(busquedaConsorcioId);
        }
                
        [HttpPost]
        public ActionResult ModificarConsorcio(Entidades.Consorcio consorcio, int IdProvincia)
        {
            ConsorcioServicio.ModificarConsorcio(consorcio, IdProvincia);
            return RedirectToAction("ListarConsorcio");
        }

        public ActionResult EliminarConsorcio(int id)
        {
            Consorcio consorcioAEliminar = ConsorcioServicio.BuscarConsorcio(id);
            return View(consorcioAEliminar);
        }
        
        [HttpPost]
        public ActionResult EliminarConsorcio(Consorcio consorcioEliminar)
        {
            ConsorcioServicio.EliminarGastos(consorcioEliminar);
            ConsorcioServicio.EliminarUnidades(consorcioEliminar);
            ConsorcioServicio.EliminarConsorcio(consorcioEliminar);
            return RedirectToAction("ListarConsorcio");
        }
    }
}