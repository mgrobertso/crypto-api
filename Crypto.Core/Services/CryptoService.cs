using Crypto.Data;
using Crypto.Data.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace Crypto.Core.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly DataContext _context;
        private readonly ILogger<CryptoService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public CryptoService(DataContext context, ILogger<CryptoService> _logger, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            this._logger = _logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task GetCryptoAsync(string path)
        {
            List<CryptoModel> coinGeckoResponse;
            await Task.Delay(10);

            var httpClient = _httpClientFactory.CreateClient();


            var response = await httpClient.GetAsync(path);


            string apiResponse = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                coinGeckoResponse = JsonConvert.DeserializeObject<List<CryptoModel>>(apiResponse);

                foreach (CryptoModel coin in coinGeckoResponse)
                {
                    var Indb = _context.Crypto.Where(x => x.Id == coin.Id);
                    if (Indb.Any())
                    {
                        _context.Crypto.Update(coin);
                    }
                    else
                    {
                        _context.Crypto.Add(coin);
                    }
                }

                await _context.SaveChangesAsync();

            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {

            }



        }

    }
}
