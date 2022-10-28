using System.ComponentModel.DataAnnotations;

namespace Crypto.Core.DTOs
{
    public class CryptoDto
    {
        public string id { get; set; }
        public string? symbol { get; set; }
        public string? name { get; set; }
        public string? image { get; set; }
        public double? current_price { get; set; }
        public double? market_cap { get; set; }
        public double? market_cap_rank { get; set; }
        public double? fully_diluted_valuation { get; }
        public DateTime? last_update { get; set; } 
        public double? high_24h { get; set; }
        public double? low_24h { get; set; } 
        public double? total_volume { get; set; }


        public double? price_change_24h { get; set; } 
        public double? price_change_percentage_24h { get; set; } 
        public double? market_cap_change_24h { get; set; } 
        public double? market_cap_change_percentage_24h { get; set; } 
        public double? total_supply { get; set; } 
        public double? max_supply { get; set; }
        public double? ath { get; set; } 
        public double? ath_change_percentage { get; set; } 
        public DateTime? ath_date { get; set; } 

    }
}
