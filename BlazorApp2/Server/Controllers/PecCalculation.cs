using BlazorApp2.Shared.PEC;
using BlazorApp2.Shared.СДЭК;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using static System.Net.Mime.MediaTypeNames;


namespace BlazorApp2.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PecCalculation : ControllerBase
    {
        [HttpPost]
        public async Task<ResultPec> Calculetion(JsonPecSearch jsonPecSearch)
        {
            ResultPec result = new ResultPec();
            string error = null;
            if(jsonPecSearch.nameCityFrom == 0 && jsonPecSearch.deliver_town == 0)
            {
                error = "Не указан город получателя и отправителя";
                result.error = error;
                return result;
            }
            if (jsonPecSearch.nameCityFrom == 0)
            {
                error = "Не указан город отправителя";
                result.error = error;
                return result;
            }
            if (jsonPecSearch.deliver_town == 0)
            {
                error = "Не указан город получателя";
                result.error = error;
                return result;
            }
            jsonPecSearch.length = jsonPecSearch.length / 100;
            jsonPecSearch.height = jsonPecSearch.height / 100;
            jsonPecSearch.width = jsonPecSearch.width / 100;
            if(jsonPecSearch.length == 0 || jsonPecSearch.height == 0 || jsonPecSearch.width == 0)
            {
                error = "Не все габариты груза указаны";
                result.error = error;
                return result;
            }
            jsonPecSearch.volume = jsonPecSearch.height * jsonPecSearch.length * jsonPecSearch.width;
            if(jsonPecSearch.volume == 0)
            {
                error = "Не указаны габариты груза";
                result.error = error;
                return result;
            }

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {

                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://calc.pecom.ru/bitrix/components/pecom/calc/ajax.php?places[0][]={jsonPecSearch.width}&pl" +
                $"aces[0][]={jsonPecSearch.length}&places[0][]={jsonPecSearch.height}&places[0][]={jsonPecSearch.volume}&plac" +
                $"es[0][]={jsonPecSearch.weight}&take[town]={jsonPecSearch.nameCityFrom}&deliver[town]={jsonPecSearch.deliver_town}&strah={jsonPecSearch.strah}"),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(body);
                decimal priceDelevery = 0;
                decimal pricePlomb = 0;
                decimal priceInsurance = 0;
                decimal priceCollection = 0;
                decimal priceDelivery = 0;
                string _periods = null;
                
                
                foreach (var auto in json)
                {
                    switch (auto.Key)
                    {
                        case "auto":
                            priceDelevery = Convert.ToDecimal(auto.Value.Last());
                            break;
                        //case "ADD_1":
                        //    pricePlomb = Convert.ToDecimal(auto.Value.Last().Last());
                        //    break;
                        case "ADD_3":
                            priceInsurance = Convert.ToDecimal(auto.Value.Last().Last());
                            break;
                        case "take":
                            priceCollection = Convert.ToDecimal(auto.Value.Last());
                            break;
                        case "deliver":
                            priceDelivery = Convert.ToDecimal(auto.Value.Last());
                            break;
                        case "periods_days":
                            _periods = auto.Value.ToString();
                            break;
                        case "error":
                            if (auto.Value.Count() >= 3)
                            {
                                error = auto.Value.First().ToString();
                                result.error = error;
                            }
                            break;
                    }
                }
                result.sumSkladAndSklad = priceDelevery + pricePlomb + priceInsurance; // Сумма доставки склад и склад +
                result.sumDorAndDor = result.sumSkladAndSklad + priceCollection + priceDelivery; // Сумма доставки с адреса на адрес +
                result.sumSkladandDor = result.sumSkladAndSklad + priceDelivery; // Сумма доставки склад до адреса +
                result.sumDorAndSklad = result.sumSkladAndSklad + priceCollection; // Сумма доставки с адреса до склад +
                result.periods = _periods;
                result.priceStrah = Convert.ToInt32(priceInsurance);
                return result;
            }
        }
    }
}
