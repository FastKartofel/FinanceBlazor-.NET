using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FinanceAPI.DAL
{

    public class Watchlist
    {
        public int WatchlistId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Company> Companies { get; set; } 
    }

}
