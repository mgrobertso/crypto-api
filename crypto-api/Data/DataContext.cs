﻿
using crypto_api.Models;

namespace crypto_api.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Crypto> Cryptos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WatchList> WatchList { get; set; }

    }
}
