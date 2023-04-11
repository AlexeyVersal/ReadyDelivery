using BlazorApp2.Shared.Address;
using BlazorApp2.Shared.models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlazorApp2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryadresController : Controller
    {
        [HttpPost]
        public async Task<Addres> GetAddress(JsonAddress jsonAddress)
        {
            using (var http = new HttpClient())
            {

                decimal i = Convert.ToDecimal(jsonAddress.cargo.length * jsonAddress.cargo.height * jsonAddress.cargo.width);
                jsonAddress.cargo.totalVolume = Math.Round(i, 2);
                string dific = "-";
                string Date = $"{jsonAddress.delivery.derival.produceDated.Value.Year}{dific}{jsonAddress.delivery.derival.produceDated.Value.Month}{dific}{jsonAddress.delivery.derival.produceDated.Value.Day}".ToString();
                jsonAddress.delivery.derival.produceDate = Date;
                var response1 = await http.PostAsJsonAsync("https://api.dellin.ru/v2/calculator.json", jsonAddress);
                if(response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    string ResponseErrorBody = await response1.Content.ReadAsStringAsync();
                    Addres addreseror = new Addres();
                    addreseror = JsonConvert.DeserializeObject<Addres>(ResponseErrorBody);
                    return addreseror;
                }
                string responseBody = await response1.Content.ReadAsStringAsync();

                Addres addres = new Addres();
                addres = JsonConvert.DeserializeObject<Addres>(responseBody);
                return addres;
            }



        }



    }
}
