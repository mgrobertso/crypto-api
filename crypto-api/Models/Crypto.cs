using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace crypto_api.Models
{
    public class Crypto
    {
        public string? Id { get; set; }
        public DateTime Last_update { get; set; } = DateTime.Now;
        public string Name { get; set;  } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public string  Image { get; set; } = string.Empty;
        public double? Current_price { get; set; } = 0.00;
        public double? High_24h { get; set;   } = 0.00;
        public double? Low_24h { get; set;  } = 0.00;
        public double? Total_volume { get; set; } = 0.00;
        public double? Market_cap { get; set; } = 0.00;
        public double? Market_cap_rank { get; set;   }=0.00;
        public double? Fully_diluted_valuation { get;  } = 0.00;
        public double? Price_change_24h { get; set; } = 0.00;
        public double? Price_change_percentage_24h { get; set;    } = 0.00;
        public double? Market_cap_change_24h { get; set;     } = 0.00;
        public double? Market_cap_change_percentage_24h { get;set;  } = 0.00;
        public double? Total_supply { get; set; } = 0.00;
        public double? Max_supply { get; set; }
        public double? Ath { get; set; } = 0.00;
        public double? Ath_change_percentage { get; set; } = 0.00;
        public DateTime Ath_date { get; set; } = DateTime.Now;

    }
}
