using FinanceAPI.DAL;

namespace FinanceAPI.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyDetails(string tickerSymbol);
        Task<IEnumerable<Company>> SearchCompanies(string query);
    }
}