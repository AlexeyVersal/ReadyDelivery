using BlazorApp2.Shared.Address;
using BlazorApp2.Shared.Magic_Trans;
using BlazorApp2.Shared.Tk_Kit;
using BlazorApp2.Shared.СДЭК;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using static BlazorApp2.Shared.Tk_Kit.CityInfo;
using static System.Net.WebRequestMethods;

namespace BlazorApp2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class tkKitTestController : ControllerBase
    {
        [HttpPost]
        public async Task<AllInfo> GetCity(NameCity nameCity)
        {
            using (var http = new HttpClient())
            {
                
                AllInfo allInfo = new AllInfo();
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Z6KmvWLroUQrywtjMKPo85pn1BSKlaHi");
                var response1 = await http.PostAsJsonAsync("https://capi.tk-kit.com/1.0/tdd/search/by-name", nameCity);
                string body = await response1.Content.ReadAsStringAsync();
                List<CityInfo> cityInfos = new List<CityInfo>();
                try
                {
                    cityInfos = JsonConvert.DeserializeObject<List<CityInfo>>(body);
                    allInfo.cityInfo = cityInfos;

                }
                catch
                {
                    CityInfo cityInfo = new CityInfo();
                    cityInfo = JsonConvert.DeserializeObject<CityInfo>(body);
                    allInfo.message = cityInfo.message;

                }
                return allInfo;
            }
        }
        [HttpPost("Result")]
        public async Task<Result> Result(RequestTkKit requestTkKit)
        {
            using (var http = new HttpClient())
            {
                foreach (var param in requestTkKit.places)
                {
                    param.volume = (param.length / 100) * (param.height / 100) * (param.width / 100);
                }
                Result result = new Result();
                result.resultTkKits = new List<ResultTkKit>();
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Z6KmvWLroUQrywtjMKPo85pn1BSKlaHi");
                var response1 = await http.PostAsJsonAsync("https://capi.tk-kit.com/1.1/order/calculate", requestTkKit);
                string body = await response1.Content.ReadAsStringAsync();
                try
                {
                    result.resultTkKits = JsonConvert.DeserializeObject<List<ResultTkKit>>(body);
                }
                catch
                {
                    var errorResult = JObject.Parse(body);
                    foreach (var i in errorResult)
                    {
                        foreach (var errorText in i.Value)
                        {
                            string error = errorText.First.ToString().Replace("[\r\n  []\r\n]", "").Replace("[","").Replace("\"", "").Replace("]","").
                                Replace("{","").Replace("}","").Replace(" weight:","").
                                Replace(" length:","").Replace(" height:","").Replace(" width:","").Replace(" volume:","").Trim();
                            result.errors.Add(error);
                        }
                    }
                }
                return result;
            }

        }
    }

}
