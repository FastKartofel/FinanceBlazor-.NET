using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FinanceFrontend.DTO; // Ensure you have DTOs that match the backend's expected response
using System.Collections.Generic;

public class CompanyService
{
    private readonly HttpClient _httpClient;

    public CompanyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<CompanyDTO>> SearchCompanies(string query)
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<CompanyDTO>>($"api/company/search?query={query}");
        return response ?? new List<CompanyDTO>();
    }

    // Add other methods as needed, for example, to get OHLC data
}
