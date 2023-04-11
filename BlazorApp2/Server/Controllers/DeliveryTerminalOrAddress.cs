using BlazorApp2.Shared.Addres_or_Terminal;
using BlazorApp2.Shared.Address;
using BlazorApp2.Shared.models;
using BlazorApp2.Shared.Terminal_or_Address;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlazorApp2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryAddresOrTerminalController : Controller
    {
        [HttpPost]
        public async Task<JsonAccept> Get(JsonSending jsonSending)
        {
            using (var http = new HttpClient())
            {  
                decimal i = Convert.ToDecimal(jsonSending.cargo.length * jsonSending.cargo.height * jsonSending.cargo.width);
                jsonSending.cargo.totalVolume = Math.Round(i, 2);
                string dific = "-";
                string aaaa = $"{jsonSending.delivery.derival.produceDated.Value.Year}{dific}{jsonSending.delivery.derival.produceDated.Value.Month}{dific}{jsonSending.delivery.derival.produceDated.Value.Day}".ToString();
                jsonSending.delivery.derival.produceDate = aaaa;
                var response1 = await http.PostAsJsonAsync("https://api.dellin.ru/v2/calculator.json", jsonSending);

                if (response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    string ResponseErrorBody = await response1.Content.ReadAsStringAsync();
                    JsonAccept addreseror = new JsonAccept();
                    addreseror = JsonConvert.DeserializeObject<JsonAccept>(ResponseErrorBody);
                    return addreseror;
                }
                string responseBody = await response1.Content.ReadAsStringAsync();

                JsonAccept jsonAccept = new JsonAccept();
                jsonAccept = JsonConvert.DeserializeObject<JsonAccept>(responseBody);
                return jsonAccept;
            }
        }
    }
}
