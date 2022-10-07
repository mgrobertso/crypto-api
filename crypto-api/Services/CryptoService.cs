using crypto_api.Models;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Linq;

namespace crypto_api.Services
{
    public class CryptoService: ICryptoService
    {
        private readonly DataContext _cryptocontext;
        private readonly ILogger<CryptoService> _logger;

        public CryptoService(DataContext Cryptocontext, ILogger<CryptoService> _logger)
        {
            _cryptocontext = Cryptocontext;
            this._logger = _logger;
        }
       
        public async Task  GetCryptoAsync(string path)
        {
            List<Crypto> coinGeckoResponse;
            await Task.Delay(10);

            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync(path))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                         coinGeckoResponse = JsonConvert.DeserializeObject<List<Crypto>>(apiResponse);

                        foreach(Crypto coin in coinGeckoResponse)
                        { 
                             _cryptocontext.Add(coin);
                        }

                        await _cryptocontext.SaveChangesAsync();

                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {

                    }
                }
            }

        }

    }
}
