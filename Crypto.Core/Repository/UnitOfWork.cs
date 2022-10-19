using Crypto.Core.DTOs;
using Crypto.Data;
using Crypto.Data.Models;

namespace crypto_api.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        private IGenericRepository<CryptoModel> _cryptos;
        private IGenericRepository<UserDto> _users;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public IGenericRepository<CryptoModel> Cryptos => _cryptos ??= (_cryptos = new GenericRepository<CryptoModel>(_context));

        public IGenericRepository<UserDto> Users => _users ??= (_users = new GenericRepository<UserDto>(_context));

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
