using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crypto.Data.Models
{
    public class WatchList
    {
        [Key]
        public Guid Id { get; set; }
        public Guid WatchId { get; set; }
        public string Coin { get; set; } = string.Empty;
    }
}
