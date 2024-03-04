using FinanceAPI.DAL;
using FinanceAPI.DTO;

namespace FinanceAPI.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyDetails(string tickerSymbol);

        Task<IEnumerable<Company>> SearchCompanies(string query);

        Task<OHLCDataDTO> GetOHLCData(string tickerSymbol, DateTime fromDate, DateTime toDate); // Define an OHLCData DTO for this

    }
}