using DataAccessLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servicios;

namespace WebApp.Controllers
{
    public class ExpensaController : Controller
    {
        ExpensasServicio expensa;

        public ExpensaController()
        {
            expensa = new ExpensasServicio();
        }

        // GET: E
        public ActionResult ListarExpensa(int id)
        {
            List<sp_Expensas_Result> expensas = expensa.GetExpensas(id);
            return View(expensas);
        }
    }
}



/*
@using System.Web.Optimization
@using DataAccessLayer.Modelos
@model List<DataAccessLayer.Modelos.sp_Expensas_Result>
@{
    ViewBag.Titulo = "Listado de Expensas";
    Layout = "~/Views/Shared/LogueadoLayout.cshtml";

}

@Scripts.Render("~/bundles/dataTables")
@Styles.Render("~/Content/dataTables")



<div class="container mb-5">
    <div class="pb-5">
        <h1 class="mb-5">Consorcios "" - Expensas</h1>



        @for (int i = 0; i < Model.Count; i++)
        {
            if (i = 0)
            {
                <p>Gasto Total Mes actual //////// (hasta el momento): /////</p>
                <p> Unidades: Model.[i]////</p>
                <p>Monto x Unidad: //////</p>
                <table class="table table-striped table-hover" id="ListadoGeneral">
                    <thead class="thead-dark">
                        <tr>
                            <th>Año</th>
                            <th>Mes</th>
                            <th>Monto</th>
                            <th>Expensas por Unidad</th>
                        </tr>
                    </thead>
                    }

                    @foreach (sp_Expensas_Result expensa in Model)
                    {
                        <tr>
                            <td>@expensa.Año</td>
                            <td>@expensa.Mes</td>
                            <td>@expensa.Gasto_Total</td>
                            <td></td>
                        </tr>
                    }
                </table>

            }

        </div>
    </div>
    */




//ORIGINAL

//@using System.Web.Optimization
//@using DataAccessLayer
//@model List<DataAccessLayer.Modelos.sp_Expensas_Result>
//@{
//    ViewBag.Titulo = "Listado de Expensas";
//    Layout = "~/Views/Shared/LogueadoLayout.cshtml";
//}

//@Scripts.Render("~/bundles/dataTables")
//@Styles.Render("~/Content/dataTables")



//< div class= "container mb-5" >


//     < div class= "pb-5" >


//          < h1 class= "mb-5" > Consorcios "" - Expensas </ h1 >



//              < p > Gasto Total Mes actual //////// (hasta el momento): /////</p>
//        <p> Unidades: ////</p>
//        < p > Monto x Unidad: //////</p>

//        < table class= "table table-striped table-hover" id = "ListadoGeneral" >


//              < thead class= "thead-dark" >


//                   < tr >


//                       < th > Año </ th >


//                       < th > Mes </ th >


//                       < th > Monto </ th >


//                       < th > Expensas por Unidad</th>
//                      </tr>
//            </thead>

//                  @foreach (DataAccessLayer.Modelos.sp_Expensas_Result expensa in Model)
//{
//                < tr >
//                    < td > @expensa.Año </ td >
//                    < td > @expensa.Mes </ td >
//                    < td > @expensa.Gasto_Total </ td >
//                    < td ></ td >
//                </ tr >
//                  }
//        </ table >
//    </ div >
//</ div >