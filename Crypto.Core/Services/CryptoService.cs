using AutoMapper;
using Crypto.Core.DTOs;
using Crypto.Data;
using Crypto.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Crypto.Core.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly DataContext _context;
        private readonly ILogger<CryptoService> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMapper _mapper;

        public CryptoService(DataContext context, ILogger<CryptoService> logger, IHttpClientFactory clientFactory, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _clientFactory = clientFactory;
            _mapper = mapper;
        }


        public async Task<bool> GetCryptoAsync(string path)
        {
            var httpClient = _clientFactory.CreateClient();

            await Task.Delay(5);

            List<CryptoDto> coinGeckoResponse;

            var response = await httpClient.GetAsync(path);

            var apiResponse =  await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                coinGeckoResponse= JsonSerializer.Deserialize<List<CryptoDto>>(apiResponse);
                _logger.LogInformation(coinGeckoResponse.Count.ToString());
                if(coinGeckoResponse.Count==0)
                {
                    return false;
                }
                foreach (var coin in coinGeckoResponse)
                {
                    var mappedCoin = _mapper.Map<CryptoModel>(coin);

                    var Indb = _context.Crypto.Where(x => x.id == mappedCoin.id);

                    if (Indb.Any())
                    {
                        _context.Crypto.Update(mappedCoin);
                    }
                    else
                    {
                        _context.Crypto.Add(mappedCoin);
                    }
                    await _context.SaveChangesAsync();
                    
                }
                return true;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new NotImplementedException();
            }

            return false;
        }

        public async Task<CryptoModel> Get(string id)
        {
            var crypto = await _context.Crypto.Where(x => x.id == id).FirstOrDefaultAsync();
            

            return crypto;
        }

        public async Task<List<CryptoModel>> GetAll()
        {
            List<CryptoModel> cryptos = await _context.Crypto.OrderByDescending(x=>x.market_cap).ToListAsync();
            return cryptos;
        }

        async Task<List<CryptoModel>> ICryptoService.GetTrend()
        {
            List<CryptoModel> cryptos =  await _context.Crypto.Where(x => x.market_cap_rank > 0 && x.market_cap_rank <= 250 && x.market_cap != 0).OrderByDescending(x=>x.market_cap).ToListAsync();
            return cryptos;
        }

        public async Task<List<CryptoModel>> BigWinner()
        {
            List<CryptoModel> cryptos = await _context.Crypto.OrderByDescending(x => x.price_change_24h).Where(x=>x.price_change_24h>=10 && x.market_cap != 0).ToListAsync();
            return cryptos;
        }
        public async Task<List<CryptoModel>> BigLoser()
        {
            List<CryptoModel> cryptos = await _context.Crypto.OrderByDescending(x => x.price_change_24h).Where(x => x.price_change_24h <= 10 &&x.price_change_24h>0&&x.market_cap!=0).ToListAsync();
            return cryptos;
        }

    }
}
