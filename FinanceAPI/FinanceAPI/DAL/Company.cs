namespace FinanceAPI.DAL
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }

        public string TickerSymbol { get; set; }

        public ICollection<Watchlist> Watchlists { get; set; }
    }

}