using crypto_api.Models;

namespace crypto_api.Services
{
    public class CryptoService: ICryptoService
    {
        private readonly DataContext _cryptocontext;

        public CryptoService(DataContext Cryptocontext)
        {
            _cryptocontext = Cryptocontext;
        }

    }
}
