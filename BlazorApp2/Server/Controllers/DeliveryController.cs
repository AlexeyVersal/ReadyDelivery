using BlazorApp2.Shared.models;
using Microsoft.AspNetCore.Mvc;
using System;
using RestSharp;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp2.Shared;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using Microsoft.Extensions.Options;
using JsonSerializer = System.Text.Json.JsonSerializer;
using BlazorApp2.Shared.City;
using BlazorApp2.Shared.Address;
using BlazorApp2.Shared.СДЭК;
using System.Net.Http.Headers;

namespace BlazorApp2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryController : Controller
    {
        [HttpPost]
        public async Task <ResponseDeliveryData> GetDeliveryData(JsonOrders jsonOrder)
        {
            string responseBody = null;
            using (var http = new HttpClient())
            {
                decimal i = Convert.ToDecimal(jsonOrder.cargo.length * jsonOrder.cargo.height * jsonOrder.cargo.width);
                jsonOrder.cargo.totalVolume = Math.Round(i, 2);
                string dific = "-";
                string aaaa = $"{jsonOrder.delivery.derival.produceDated.Value.Year}{dific}{jsonOrder.delivery.derival.produceDated.Value.Month}{dific}{jsonOrder.delivery.derival.produceDated.Value.Day}".ToString();
                jsonOrder.delivery.derival.produceDate = aaaa;
                var response1 = await http.PostAsJsonAsync("https://api.dellin.ru/v2/calculator.json", jsonOrder);
                if(response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    string ResponseErrorBody = await response1.Content.ReadAsStringAsync();
                    ResponseDeliveryData addreseror = new ResponseDeliveryData();
                    addreseror = JsonConvert.DeserializeObject<ResponseDeliveryData>(ResponseErrorBody);
                    return addreseror;
                }
                responseBody =  await response1.Content.ReadAsStringAsync();
                ResponseDeliveryData responseDeliveryDatas = new ResponseDeliveryData();
                responseDeliveryDatas = JsonConvert.DeserializeObject<ResponseDeliveryData>(responseBody);
                return responseDeliveryDatas;
            }
        }
    } 
}
