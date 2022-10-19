
using Crypto.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Crypto.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<CryptoModel> Crypto { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WatchList> WatchList { get; set; }


    }
}
