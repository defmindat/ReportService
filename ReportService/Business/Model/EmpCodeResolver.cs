﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Business.Domain
{
    public class EmpCodeResolver
    {
        public static async Task<string> GetCode(string inn)
        {
            using (var client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://buh.local/api/inn/" + inn).ConfigureAwait(false);
                return result;
            }
        }
    }
}
