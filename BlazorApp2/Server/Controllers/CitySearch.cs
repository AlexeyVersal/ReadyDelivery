using BlazorApp2.Shared.Magic_Trans;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlazorApp2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitySearchController : ControllerBase
    {
        [HttpGet("{fromCity}")]
        public Magic_Json? Get(string fromCity)
        {
            var clientHandler = new HttpClientHandler
            {
                UseCookies = false,
            };
            var client = new HttpClient(clientHandler);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://magic-trans.ru/api/v1/dictionary/getCityList&name={fromCity}&"),
                Headers =
    {
        { "cookie", "__ddg1_=dZ0DGICWe18iBmorzfk8; PHPSESSID=XLO2JRogsY5712ZBkxj177Y6ObvXfK5n" },
    },
            };
            using (var response = client.SendAsync(request))
            {
                var body = response.Result.Content.ReadAsStringAsync().Result;
                Magic_Json magic_Json = new Magic_Json();
                magic_Json = JsonConvert.DeserializeObject<Magic_Json>(body);

                Console.WriteLine("");
                return magic_Json;
            }

        }
    }
}
