using DataAccessLayer.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ExpensasServicio
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Obtiene las expensasa a traves de una Web APi Rest</returns>
        public List<sp_Expensas_Result> GetExpensas(int id)
        {
            var url = $"http://localhost:49169/api/ExpensasAWR/" + id;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return new List<sp_Expensas_Result>();
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        var result = JsonConvert.DeserializeObject<List<sp_Expensas_Result>>(responseBody);
                        return result;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expensas"></param>
        /// <returns>
        /// Chequea si hay un registro con el año y mes actual. Si no hay lo agrega
        /// </returns>
        public List<sp_Expensas_Result> DeterminaMesActual(List<sp_Expensas_Result> expensas)
        {
            if (DateTime.Now.Year == expensas[0].Año && DateTime.Now.Month == expensas[0].Mes)
            {
                return expensas;
            }
            else
            {
                sp_Expensas_Result mesActual = new sp_Expensas_Result();
                mesActual.Gasto_Total = 0;

                expensas.Insert(0, mesActual);

                return expensas;
            }
        }
    }
}