using Crypto.Core.Services;
using Crypto.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace crypto_api.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class WatchListController : ControllerBase
    {
        private readonly IWatchListService _watchList;

        public WatchListController(IWatchListService watchList)
        {
            _watchList = watchList;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var list = await _watchList.get(Guid.Parse(id));

            return Ok(list);
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult> AddList(string[] list)
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;


            foreach (string item in list)
            {

                _watchList.add(Guid.Parse(id), item);
            }

            var watchlist = await _watchList.get(Guid.Parse(id));

            return Ok(watchlist);
        }

        [Authorize]
        [HttpPost("remove")]
        public async Task<ActionResult> RemoveList(string[] list)
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            foreach (string item in list)
            {
                _watchList.remove(Guid.Parse(id), item);
            }

            return Ok(list);
        }

    }
}
