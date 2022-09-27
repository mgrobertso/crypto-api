namespace crypto_api
{
    public class Crypto
    {
        public string? Id { get; set; }
        public string Last_update { get; set; }= string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public double Current_price { get; set; } = 0.00;
        public double High_24h { get; set; } = 0.00;
        public double Low_24h { get; set; } = 0.00;
        public double Total_volume  { get; set; } = 0.00;

    }
}
