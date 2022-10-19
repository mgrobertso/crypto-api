using AutoMapper;
using Crypto.Core.DTOs;
using Crypto.Data.Models;
using crypto_api.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace crypto_api.Controllers
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("api/[controller]")]

    public class CryptoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CryptoController> _logger;
        private readonly IMapper _mapper;

        public CryptoController(IUnitOfWork unitOfWork, ILogger<CryptoController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var cryptos = await _unitOfWork.Cryptos.GetAll();
                var result = _mapper.Map<IList<CryptoModel>>(cryptos);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error{nameof(Get)}");
                return StatusCode(500, "Server Error, try again later");
            }


        }

         [HttpGet("{id}")]

         public async Task<ActionResult> Get(string id)
         {

            try
            {
                var crypto = await _unitOfWork.Cryptos.Get(x=>x.Id == id);
                var result = _mapper.Map<CryptoModel>(crypto);
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
