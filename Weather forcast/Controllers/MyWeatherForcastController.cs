using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
namespace Weather_forcast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyWeatherForcastController : ControllerBase
    {
        [HttpGet("[action]/{city}")]
        public async Task<string> GetWeatherAsync(string city)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync($"https://api.weatherapi.com/v1/forecast.json?key=39f8ecaf506c4f76b3f55139222906&q={city}&days=1&api=yes&alerts=yes");
                    response.EnsureSuccessStatusCode();
                    var stringResult = await response.Content.ReadAsStringAsync();
                    string[] arr = stringResult.Split(',');
                    string sentenceTemp = arr.FirstOrDefault(s => s.Contains("temp_c"));
                    int indexTemp = sentenceTemp.IndexOf(':');
                    string temp = sentenceTemp.Substring(indexTemp + 1);
                    string sentenceCondition = arr.FirstOrDefault(s => s.Contains("condition"));
                    int indexCondition = sentenceCondition.LastIndexOf(':');
                    string condition = sentenceCondition.Substring(indexCondition + 2);
                    int startCat = condition.IndexOf("\"");
                    condition = condition.Substring(0, startCat);
                    string weather = $"the weather in {city} is: temp {temp} condition {condition}";
                    return weather;
                }                                    

                catch (HttpRequestException httpRequestException)
                {
                return "BadRequest";
                }
            }
        }
    }
}
