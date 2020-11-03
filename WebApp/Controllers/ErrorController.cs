using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Inicio(int error = 0)
        {
            switch (error)
            {
                case 404:
                    ViewBag.Title = "Ocurrio un error inesperado";
                    ViewBag.DescripcionError = "Esto es muy vergonzoso, esperemos que no vuelva a pasar ..";
                    break;

                case 500:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.DescripcionError = "La URL que está intentando ingresar no existe";
                    break;

                default:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.DescripcionError = "Algo salio muy mal :( ..";
                    break;
            }

            return View("~/views/error/PaginaError.cshtml");
        }
    }
}