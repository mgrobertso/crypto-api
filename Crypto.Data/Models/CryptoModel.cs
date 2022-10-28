using System.ComponentModel.DataAnnotations;

namespace Crypto.Data.Models
{
    public class CryptoModel
    {
        [Required]
        [Key]

        public string id { get; set; }
        public DateTime last_update { get; set; } = DateTime.Now;
        [Required]
        public string name { get; set; } = string.Empty;
        [Required]
        public string symbol { get; set; } = string.Empty;
        [Required]
        public string image { get; set; } = string.Empty;
        [Required]
        public double current_price { get; set; } = 0.00;
        [Required]
        public double high_24h { get; set; } = 0.00;
        [Required]
        public double low_24h { get; set; } = 0.00;
        [Required]
        public double total_volume { get; set; } = 0.00;
        public double market_cap { get; set; } = 0.00;
        public double market_cap_rank { get; set; } = 0.00;
        public double fully_diluted_valuation { get; } = 0.00;
        public double price_change_24h { get; set; } = 0.00;
        public double price_change_percentage_24h { get; set; } = 0.00;
        public double market_cap_change_24h { get; set; } = 0.00;
        public double market_cap_change_percentage_24h { get; set; } = 0.00;
        public double total_supply { get; set; } = 0.00;
        public double max_supply { get; set; }
        public double ath { get; set; } = 0.00;
        public double ath_change_percentage { get; set; } = 0.00;
        public DateTime ath_date { get; set; } = DateTime.Now;

    }
}
