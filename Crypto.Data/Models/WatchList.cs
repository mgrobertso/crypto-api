using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crypto.Data.Models
{
    public class WatchList
    {
        [ForeignKey("Id")]
        public Guid Id { get; set; }
        [Key]
        public Guid WatchId { get; set; }

        public string Coin { get; set; } = string.Empty;
    }
}
