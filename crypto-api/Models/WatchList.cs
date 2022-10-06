using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crypto_api.Models
{
    public class WatchList
    {
        [ForeignKey("Id")] 
        public string Id { get; set; }
        public string WatchId { get; set; }

        public string Coin { get; } = string.Empty;
    }
}
