using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Web.Helpers;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
namespace Weather_forcast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Weather3DaysController : ControllerBase
    {
        [HttpGet("[action]/{city}")]
        public async Task<string> GetWeatherAsync(string city)
        {
            using (var client = new HttpClient())
            {
                
                    var response = await client.GetAsync($"https://api.weatherapi.com/v1/forecast.json?key=39f8ecaf506c4f76b3f55139222906&q={city}&days=3&api=yes&alerts=yes");
                    response.EnsureSuccessStatusCode();
                    var stringResult = await response.Content.ReadAsStringAsync();
                //JObject json = JObject.Parse(stringResult);
                //Json stringjson = JsonConvert.SerializeObject(stringResult);
                   //dynamic json = JsonConvert.DeserializeObject(stringResult);
                return stringResult;
                    
               
            }
        }
        }
}
