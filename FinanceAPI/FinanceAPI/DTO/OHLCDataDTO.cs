namespace FinanceAPI.DTO
{
    public class OHLCDataDTO
    {
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }
        // Additional fields
        public decimal AfterHours { get; set; }
        public decimal PreMarket { get; set; }
    }


}
