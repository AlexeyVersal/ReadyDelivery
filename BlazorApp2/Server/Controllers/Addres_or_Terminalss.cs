using BlazorApp2.Shared.Addres_or_Terminal;
using BlazorApp2.Shared.Address;
using BlazorApp2.Shared.models;
using BlazorApp2.Shared.Terminal_or_Address;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace BlazorApp2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Addres_or_TerminalssController : Controller
    {
        [HttpPost]
        public async Task<JsonAcceptAdress> GetAddres(JsonSendingAdres jsonSendingAdres)
        {
            using(var http = new HttpClient())
            {
                decimal i = Convert.ToDecimal(jsonSendingAdres.cargo.length * jsonSendingAdres.cargo.height * jsonSendingAdres.cargo.width);
                jsonSendingAdres.cargo.totalVolume = Math.Round(i, 2);
                string dific = "-";
                string aaaa = $"{jsonSendingAdres.delivery.derival.produceDated.Value.Year}{dific}{jsonSendingAdres.delivery.derival.produceDated.Value.Month}{dific}{jsonSendingAdres.delivery.derival.produceDated.Value.Day}".ToString();
                jsonSendingAdres.delivery.derival.produceDate = aaaa;
                var response1 = await http.PostAsJsonAsync("https://api.dellin.ru/v2/calculator.json", jsonSendingAdres);

                if (response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    string ResponseErrorBody = await response1.Content.ReadAsStringAsync();
                    JsonAcceptAdress addreseror = new JsonAcceptAdress();
                    addreseror = JsonConvert.DeserializeObject<JsonAcceptAdress>(ResponseErrorBody);
                    return addreseror;
                }
                string responseBody = await response1.Content.ReadAsStringAsync();
                
                JsonAcceptAdress jsonSendingAdres1 = new JsonAcceptAdress();
                jsonSendingAdres1 = JsonConvert.DeserializeObject<JsonAcceptAdress>(responseBody);

                return jsonSendingAdres1;
            }
           
        }
    }
    
    
}
