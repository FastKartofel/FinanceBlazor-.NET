using FinanceAPI.DAL;
using FinanceAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FinanceAPI.DTO;
using Microsoft.EntityFrameworkCore;

public class CompanyService : ICompanyService
{
    private readonly FinanceDbContext _context;
    private readonly HttpClient _httpClient;
    private readonly string _polygonApiKey = "https://api.polygon.io/v2/aggs/ticker/AAPL/range/1/day/2023-01-09/2023-01-09?apiKey=MW4nYuJZIOilEdws2RuJhYgfo7u85etZ"; // Update with your actual API key

    public CompanyService(FinanceDbContext context, IHttpClientFactory httpClientFactory)
    {
        _context = context;
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri("https://api.polygon.io/");
    }

    public async Task<Company> GetCompanyDetails(string tickerSymbol)
    {
        var company = await _context.Companies.FirstOrDefaultAsync(c => c.TickerSymbol == tickerSymbol);
        if (company != null) return company;

        var response = await _httpClient.GetAsync($"v3/reference/tickers/{tickerSymbol}?apiKey={_polygonApiKey}");
        if (!response.IsSuccessStatusCode) return null;

        var content = await response.Content.ReadAsStringAsync();
        var polygonCompanyDetails = JsonConvert.DeserializeObject<CompanyDetailsDTO>(content);

        var newCompany = new Company
        {
            Name = polygonCompanyDetails.Name,
            TickerSymbol = tickerSymbol,
            // Map additional fields as necessary
        };

        _context.Companies.Add(newCompany);
        await _context.SaveChangesAsync();

        return newCompany;
    }

    public async Task<OHLCDataDTO> GetOHLCData(string tickerSymbol, DateTime fromDate, DateTime toDate)
    {
        var requestUrl = $"v2/aggs/ticker/{tickerSymbol}/range/1/day/{fromDate:yyyy-MM-dd}/{toDate:yyyy-MM-dd}?apiKey={_polygonApiKey}";
        var response = await _httpClient.GetAsync(requestUrl);
        if (!response.IsSuccessStatusCode) return null;

        var content = await response.Content.ReadAsStringAsync();
        var ohlcResponse = JsonConvert.DeserializeObject<PolygonOHLCResponse>(content);

        // Assuming there's a logic to convert the first result into OHLCDataDTO
        // This example takes the first result for simplicity. Adjust as necessary.
        var ohlcData = ohlcResponse.Results.Select(r => new OHLCDataDTO
        {
            Date = DateTimeOffset.FromUnixTimeMilliseconds(r.T).DateTime,
            Open = r.O,
            High = r.H,
            Low = r.L,
            Close = r.C,
            Volume = r.V
            // Map additional fields if needed
        }).FirstOrDefault();

        return ohlcData;
    }

    public async Task<IEnumerable<Company>> SearchCompanies(string query)
    {
        return await _context.Companies
                             .Where(c => c.Name.Contains(query) || c.TickerSymbol.Contains(query))
                             .ToListAsync();
    }
}