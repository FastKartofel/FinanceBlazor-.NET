using FinanceAPI.DAL;
using FinanceAPI.Services.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FinanceAPI.DTO;
using Microsoft.EntityFrameworkCore;

public class CompanyService : ICompanyService
{
    private readonly FinanceDbContext _context;
    private readonly HttpClient _httpClient;
    private readonly string _polygonApiKey = "https://api.polygon.io/v2/aggs/ticker/AAPL/range/1/day/2023-01-09/2023-01-09?apiKey=*";

    public CompanyService(FinanceDbContext context, IHttpClientFactory httpClientFactory)
    {
        _context = context;
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri("https://api.polygon.io/vX/");
    }

    public async Task<Company> GetCompanyDetails(string tickerSymbol)
    {
        // Check if company exists in DB
        var company = await _context.Companies.FirstOrDefaultAsync(c => c.TickerSymbol == tickerSymbol);
        if (company != null) return company;

        // Fetch from Polygon.io if not in DB
        var response = await _httpClient.GetAsync($"reference/tickers/{tickerSymbol}?apiKey={_polygonApiKey}");
        if (!response.IsSuccessStatusCode) return null;

        var content = await response.Content.ReadAsStringAsync();
        var polygonCompany = JsonConvert.DeserializeObject<PolygonCompany>(content);

        // Map to your Company model
        var newCompany = new Company
        {
            Name = polygonCompany.Name,
            TickerSymbol = polygonCompany.Symbol,
            // Map other fields as necessary
        };

        _context.Companies.Add(newCompany);
        await _context.SaveChangesAsync();

        return newCompany;
    }

    public async Task<IEnumerable<Company>> SearchCompanies(string query)
    {
        // Implement search logic, potentially using Polygon.io's search endpoints or local DB search
        throw new NotImplementedException();
    }
}