using System.ComponentModel.DataAnnotations;

namespace Crypto.Core.DTOs
{
    public class CreateWatchListDto
    {
        [Required]
        public string coin { get; set; }
    }

    public class WatchListDto : CreateWatchListDto
    {
        public Guid Id { get; set; }
        public Guid WatchId { get; set; }

    }
}
