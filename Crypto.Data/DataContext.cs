
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
        public DbSet<CryptoDetails> Details { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CryptoModel>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedOnAdd();
            });
            builder.Entity<CryptoDetails>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedOnAdd();
            });
            builder.Entity<CryptoDetails.market_data>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedOnAdd();
            });
        }


    }
}
