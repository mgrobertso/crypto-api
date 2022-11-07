using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Data.Models
{
    public class CryptoDetails
    {
        [Key]
        public string id { get; set; } = string.Empty;
        public string? name { get; set; } = string.Empty;
        public string? symbol { get; set; } = string.Empty;
        public int? asset_platform_id { get; set; } = 0;
        public DateTime? block_time_in_minutes { get; set; }
        public string? hashing_algorithm { get; set; } = string.Empty;
        public int? market_cap_rank { get; set; }
        public market_data? _market_Data { get; set; } = null;


        public class market_data
        {
            [Key]
            public string id { get; set; } = string.Empty;
            public int? current_price { get; set; }
            public int? high_24h { get; set; }
            public int? low_24h { get; set; }
        }

    }
}

