using BlazorApp2.Shared.City;
using BlazorApp2.Shared.models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static BlazorApp2.Shared.models.ResponseDeliveryData;

namespace BlazorApp2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FindTerminalsController : Controller
    {
       public async Task<Terminals> GetCity(JsonCity jsonCity)
        {
            using(var http = new HttpClient())
            {
                var response1 = await http.PostAsJsonAsync("https://api.dellin.ru/v2/public/kladr.json", jsonCity);
                string responseBody = await response1.Content.ReadAsStringAsync();
                JsonReady jsonReady = new JsonReady();
                jsonReady = JsonConvert.DeserializeObject<JsonReady>(responseBody);

                JsonTerminals jsonTerminals = new JsonTerminals();
                Terminals terminals = new Terminals();
                foreach (var items in jsonReady.cities)
                {
                    if(items.isTerminal != 0)
                    {
                        
                        jsonTerminals.code = items.code;
                        var response2 = await http.PostAsJsonAsync("https://api.dellin.ru/v1/public/request_terminals.json", jsonTerminals);
                        string responseBody2 = await response2.Content.ReadAsStringAsync();
                        terminals = JsonConvert.DeserializeObject<Terminals>(responseBody2);
                    }
                    
                }
                return terminals;

                //string responseBody2 = await response1.Content.ReadAsStringAsync();


            }
            
        }
    }
}
