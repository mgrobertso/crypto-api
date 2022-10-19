using Crypto.Core.DTOs;
using Crypto.Data.Models;

namespace crypto_api.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<CryptoModel> Cryptos { get; }
        IGenericRepository<UserDto> Users { get; }
        Task Save();
    }
}
