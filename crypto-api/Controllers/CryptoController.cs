using AutoMapper;
using Crypto.Core.DTOs;
using Crypto.Core.Services;
using Crypto.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace crypto_api.Controllers
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("api/[controller]")]

    public class CryptoController : ControllerBase
    {
        private readonly ILogger<CryptoController> _logger;
        private readonly IMapper _mapper;
        private readonly ICryptoService _cryptoService;

        public CryptoController( ILogger<CryptoController> logger, IMapper mapper, ICryptoService cryptoService)
        {
            _logger = logger;
            _mapper = mapper;
            _cryptoService = cryptoService;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var cryptos =  await _cryptoService.GetTrend();
                var result = _mapper.Map<List<CryptoDto>>(cryptos);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error{nameof(Get)}");
                return StatusCode(500, "Server Error, try again later");
            }
        }

        [a]
        [HttpGet("{id}")]

         public async Task<ActionResult> Get(string id)
         {

            try
            {
                var crypto =  await _cryptoService.Get(id);
                var result = _mapper.Map<CryptoDto>(crypto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error{nameof(Get)}");
                return StatusCode(500, "Server Error, try again later");
            }
        }

    }
}
