using BlazorApp2.Shared.models;
using BlazorApp2.Shared.PEC;
using BlazorApp2.Shared.Terminal_or_Address;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using static System.Net.WebRequestMethods;

namespace BlazorApp2.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PeKTestController : ControllerBase
    {
        [HttpGet("{nameCityFrom}")]
        public async Task<List<DataCity>>? FindCityID(string nameCityFrom)
        {
            using (var client = new HttpClient())
            {  
                if (nameCityFrom == "Москва")
                    nameCityFrom = nameCityFrom + " " + "Восток";
                if (nameCityFrom == "Росто")
                    nameCityFrom = "Ростов-на-Дону";
                if (nameCityFrom == "Санкт")
                    nameCityFrom = "Санкт-Петербург";
                var response1 = await client.GetAsync("http://www.pecom.ru/ru/calc/towns.php");
                string result = response1.Content.ReadAsStringAsync().Result;
                var userObj = JObject.Parse(result);
                List<DataCity> dataCity = new List<DataCity>();                
                JsonPecSearch jsonPecSearch = new JsonPecSearch();
                foreach (var i in userObj)
                {
                    foreach (var b in i.Value)
                    {
                        string g = b.Parent.ToString();
                        string? nameCity = b.ToString().Split(":").Last().Replace("\"", "").Trim();
                        if (nameCityFrom == nameCity)
                        {
                            var IID = JObject.Parse(g);
                            foreach(var IDCity in IID)
                            {
                                DataCity data = new DataCity();
                                string? idCity = IDCity.ToString().Split(",").FirstOrDefault().Replace("\"", "").Replace("[","").Trim();        
                                string cityName = IDCity.ToString().Split(",").Last().Replace("\"", "").Replace("]", "").Trim();    
                                data.id = Convert.ToInt32(idCity);
                                data.name = cityName;
                                dataCity.Add(data);
                            }                         
                        }                 
                    }                  
                }
                return dataCity;
            }


        }
    }
}
