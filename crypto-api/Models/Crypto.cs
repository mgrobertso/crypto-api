namespace crypto_api.Models
{
    public class Crypto
    {
        public string? Id { get; set; }
        public string Last_update { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public double Current_price { get; set; } = 0.00;
        public double High_24h { get; set; } = 0.00;
        public double Low_24h { get; set; } = 0.00;
        public double Total_volume { get; set; } = 0.00;
        public double market_cap { get; set; } = 0.00;
        public double market_cap_rank { get; set; }=0.00;
        public double fully_diluted_valuation { get; set; } = 0.00;
        public double price_change_24h { get; set; } = 0.00;
        public double price_change_percentage_24h { get; set; } = 0.00;
        public double market_cap_change_24h { get; set; } = 0.00;
        public double market_cap_change_percentage_24h { get; set; } = 0.00;
        public double total_supply { get; set; } = 0.00;
        public double max_supply { get; set; } = 0.00;
        public double ath { get; set; } = 0.00;
        public double ath_change_percentage { get; set; } = 0.00;
        public DateTime ath_date {  get; set; } = DateTime.Now;
        public double roi { get; set; } = 0.00;

    }
}
