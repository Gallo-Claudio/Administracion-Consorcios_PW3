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
        public List<sp_Expensas_Result> GetExpensas(int id)
        {
            var url = $"http://localhost:49169/api/ExpensasAWR/"+id;
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
    }
}
