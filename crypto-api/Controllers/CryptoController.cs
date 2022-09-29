using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace crypto_api.Controllers
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("api/[controller]")]

    public class CryptoController : ControllerBase
    {
        private readonly DataContext _context;

        public CryptoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Crypto>>> Get()
        {

            return Ok( await _context.Cryptos.ToListAsync());
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<Crypto>> Get(string id)
        {
            var crypto = await _context.Cryptos.FindAsync(id);
            if (crypto == null)
                return BadRequest("Crypto not Found");
            return Ok(crypto);
        }


        [HttpPost]
        public async Task<ActionResult<List<Crypto>>> AddCrypto(Crypto crypto)
        {
            _context.Cryptos.Add(crypto);
            await _context.SaveChangesAsync();
            return Ok(await _context.Cryptos.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Crypto>>> UpdateCrypto(Crypto Asset)
        {
            var dbcrypto = await _context.Cryptos.FindAsync(Asset.Id);
            if (dbcrypto == null)
                return BadRequest("Crypto not Found");

            dbcrypto.Current_price = Asset.Current_price;
            dbcrypto.High_24h = Asset.High_24h;
            dbcrypto.Low_24h = Asset.Low_24h;
            dbcrypto.Name = Asset.Name;

            await _context.SaveChangesAsync();
            return Ok(await _context.Cryptos.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Crypto>>> Delete(string id)
        {
            var  dbCrypto = await _context.Cryptos.FindAsync(id);
            if (dbCrypto == null)
                return BadRequest("Crypto not Found");

            _context.Cryptos.Remove(dbCrypto);
            await _context.SaveChangesAsync();

            return Ok(await _context.Cryptos.ToListAsync());
        }

    }
}
