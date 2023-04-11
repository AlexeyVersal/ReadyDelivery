using Microsoft.AspNetCore.Mvc;
using BlazorApp2.Shared.Magic_Trans;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlazorApp2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationMagicTransController : ControllerBase
    {
        [HttpPost]
        public async Task<ResultMagicTrans> Calculation(RequestData requestData)
        {
            requestData.length = requestData.length / 100;
            requestData.width = requestData.width / 100;
            requestData.height = requestData.height / 100;
            decimal sumStrah = 40;
            if (requestData.priceStrah >= 20250)
            {
                sumStrah = Convert.ToDecimal(Math.Round(requestData.priceStrah * 0.002, 0));
            }
            var clientHandler = new HttpClientHandler
            {
                UseCookies = false,
            };
            var client = new HttpClient(clientHandler);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://magic-trans.ru/api/v1/delivery/calculate/?from={requestData.from}&to={requestData.to}&items[0]" +
                $"[count]={requestData.count}&items[0][weight]={requestData.weight}&items[0][length]={requestData.length}&items[0][width]={requestData.width}&items[0][height]={requestData.height}"),
                Headers =
    {
        { "cookie", "__ddg1_=dZ0DGICWe18iBmorzfk8; PHPSESSID=uSwpg48q2TRQZl4iHGI7rF0w8VpFMUUQ" },
        { "Authorization", "Bearer " },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                ResultMagicTrans result = new ResultMagicTrans();
                result = JsonConvert.DeserializeObject<ResultMagicTrans>(body);
                if (result.error != 0)
                {
                    return result;
                }
                result._sumStrah = sumStrah;
                result.result.price += sumStrah - 40;
                return result;
            }
        }


    }
}
