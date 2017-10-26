using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    class Auth0Service
    {

        public async Task<bool> Logout()
        {
            using (var client = new HttpClient())
            {
                var url = string.Format("https://weatherapp.auth0.com/v2/logout");
                string resp;
                try
                {
                    resp = await client.GetStringAsync(url);
                    resp = resp.Replace("\\n", "");
                }
                catch (Exception e)
                {
                    throw e;
                }
                return false;
            }
        }
    }
}
