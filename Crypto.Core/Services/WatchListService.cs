using Crypto.Data;
using Crypto.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace Crypto.Core.Services
{
    public class WatchListService : IWatchListService
    {
        private readonly DataContext _context;

        public WatchListService(DataContext context)
        {
            _context = context;
        }


        public async void add(Guid id, string name)
        {


            var watchList = _context.WatchList.Where(x => x.WatchId == id).ToList();
            if (watchList.FindIndex(x => x.WatchId == id && x.Coin == name) == -1)
            {
                var list = new WatchList();
                list.Id = Guid.NewGuid();
                list.Coin = name;
                list.WatchId = id;
                await _context.WatchList.AddAsync(list);
                 _context.SaveChanges();
            }
        }

        public async Task<List<WatchList>> get(Guid id)
        {
            var WatchList = await _context.WatchList.Where(x => x.WatchId == id).ToListAsync();
            return WatchList;
        }

        public async void remove(Guid id, string name)
        {
            var WatchList = await _context.WatchList.Where(x => x.WatchId == id && x.Coin == name).FirstOrDefaultAsync();
            if (WatchList != null)
            {
                _context.WatchList.Remove(WatchList);
                _context.SaveChanges();
            }


        }
    }
}
