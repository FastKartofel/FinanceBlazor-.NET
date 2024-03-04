namespace FinanceAPI.DTO
{
    public class CompanyDetailsDTO
    {
        public string Logo { get; set; }
        public DateTime ListDate { get; set; }
        public long CIK { get; set; }
        public string Bloomberg { get; set; }
        public string FIGI { get; set; }
        public string LEI { get; set; }
        public int SIC { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
        public string Sector { get; set; }
        public long MarketCap { get; set; }
        public int Employees { get; set; }
        public string Phone { get; set; }
        public string CEO { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Exchange { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string ExchangeSymbol { get; set; }
        public string HQAddress { get; set; }
        public string HQState { get; set; }
        public string HQCountry { get; set; }
        public string Type { get; set; }
        public DateTime Updated { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Similar { get; set; }
        public bool Active { get; set; }
    }

}
