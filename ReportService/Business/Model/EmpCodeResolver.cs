using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ReportService.Domain
{
    public class EmpCodeResolver
    {
        public static async Task<string> GetCode(string inn)
        {
            string res ="";
            try
            {
                var client = new HttpClient();
                res = await client.GetStringAsync("http://buh.local/api/inn/" + inn);
            }
            catch (Exception exc)
            {
                //логирование
            }
            return res;
            
        }
    }
}
