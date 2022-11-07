using AutoMapper;
using Crypto.Core.DTOs;
using Crypto.Data;
using Crypto.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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


            var watchList = _context.WatchList.Where(x => x.Id == id).ToList();
            var list = new WatchList();
            list.Coin = name;
            list.Id = id;
            list.WatchId = id;
            if(watchList.Contains(list))
            {
            }
            if (watchList.Any())
            {
                _context.WatchList.Add(list);
                 _context.SaveChanges();
            }
        }

        public async Task<WatchList> Get(Guid id)
        {
            var WatchList = _context.WatchList.Where(x => x.Id == id).FirstOrDefault();
            if(WatchList != null)
            {
                return WatchList;
            }

            return WatchList;

        }

        public void remove(Guid id, string name)
        {
            var WatchList = _context.WatchList.Where(x => x.Coin == name).FirstOrDefault();

             
        }
    }
}
