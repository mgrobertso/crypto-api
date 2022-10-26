using Crypto.Data.Models;

namespace Crypto.Core.Services
{
    public interface ICryptoService
    {
        Task GetCryptoAsync(string path);
        Task<CryptoModel>Get(string id);
        Task<List<CryptoModel>> GetAll();
    }
}
 