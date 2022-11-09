using Crypto.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Core.Services
{
    public interface IWatchListService
    {

        Task<List<WatchList>> get(Guid id);
        void add(Guid id, string name);
        void remove(Guid id, string name);
    }
}
