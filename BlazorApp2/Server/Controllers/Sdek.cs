using BlazorApp2.Shared.СДЭК;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BlazorApp2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CDEKController : Controller
    {
        [HttpPost]
        public async Task<JsonAceptSDEC> GetJsonAceptAsync(JsonSDEC jsonSDEC)
        {
            using (var http = new HttpClient())
            {
                
                var clientHandler = new HttpClientHandler
                {
                    UseCookies = false,
                };
                var client = new HttpClient(clientHandler);
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://api.cdek.ru/v2/oauth/token?parameters="),
                    Headers =
                        {
                            { "cookie", "JSESSIONID=node05htk3lxkt0th3qohsazcn37b10.node0" },
                        },
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
                        {
                            { "grant_type", "client_credentials" },
                            { "client_id", "JdOcbiah6QFVfJrlbHFf56jjtVjtDFCG" },
                            { "client_secret", "1VibrfL3TcpIGUNUaB3Rr2U23YGAtFdE" },
                        }),
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Token token = new Token();

                    token = JsonConvert.DeserializeObject<Token>(body);

                    jsonSDEC.packages.weight = Math.Round(jsonSDEC.packages.weight * 1000, 0);
                    if(jsonSDEC.packages.weight == 0)
                    {
                        JsonAceptSDEC error = new JsonAceptSDEC();
                        error._error = "Не корректно введены габариты груза";
                        return error;
                    }
                    else if(jsonSDEC.packages.length == 0 || jsonSDEC.packages.height == 0 || jsonSDEC.packages.width == 0)
                    {
                        JsonAceptSDEC error = new JsonAceptSDEC();
                        error._error = "Не корректно введены габариты груза";
                        return error;
                    }

                        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{token.access_token}");
                    var response1 = await http.PostAsJsonAsync("https://api.cdek.ru/v2/calculator/tarifflist", jsonSDEC);

                    string responseBody2 = await response1.Content.ReadAsStringAsync();

                    JsonAceptSDEC jsonAceptSDEC = new JsonAceptSDEC();
                    jsonAceptSDEC = JsonConvert.DeserializeObject<JsonAceptSDEC>(responseBody2);

                    foreach (var priceStrah in jsonAceptSDEC.tariff_codes)
                    {
                        if(jsonSDEC._sumStrah >= 3000)
                        {
                            decimal price = Convert.ToDecimal(Math.Round(jsonSDEC._sumStrah * 0.008, 0));
                            priceStrah._priceStrah = price;
                            priceStrah.delivery_sum += priceStrah._priceStrah;
                        }
                    }
                    
                    return jsonAceptSDEC;
                }




            }
        }

    }
}
