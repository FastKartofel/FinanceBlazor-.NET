namespace FinanceFrontend.DTO
{
    public class CompanyDTO
    {
        public int CompanyId { get; set; } // If you're sending an identifier from your database
        public string Name { get; set; }
        public string TickerSymbol { get; set; }
        public string Logo { get; set; } // URL to the company's logo if available
        public string Industry { get; set; }
        public string Sector { get; set; }
        public long MarketCap { get; set; }
        public int Employees { get; set; }
        public string Phone { get; set; }
        public string CEO { get; set; }
        public string Url { get; set; } // Company's website
        public string Description { get; set; }
        public string Exchange { get; set; }
        public string HQAddress { get; set; }
        public List<string> Tags { get; set; } // Additional categories/tags associated with the company
        public bool Active { get; set; } // Indicates if the company is actively traded
    }

}
