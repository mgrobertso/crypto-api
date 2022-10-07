using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crypto_api.Models
{
    public class WatchList
    {
        [ForeignKey("Id")] 
        public Guid Id { get; set; } 
        public Guid WatchId { get; set; }

        public string Coin { get; } = string.Empty;
    }
}
