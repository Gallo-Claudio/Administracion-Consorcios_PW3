using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWebRest.Models
{
    public class ExpensasDTO
    {        
        public int Año { get; set; }
        public int Mes { get; set; }
        public decimal Gasto_Total { get; set; }
    }
}