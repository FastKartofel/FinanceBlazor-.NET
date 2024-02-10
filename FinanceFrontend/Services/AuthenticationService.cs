using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using FinanceFrontend.DTO;

namespace FinanceFrontend.Services
{
    public class AuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<bool> Register(UserRegistrationDto userRegistration)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/auth/register", userRegistration);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Log or handle the error response from the server
                    return false;
                }
            }
            catch (HttpRequestException e)
            {
                // Handle HTTP request exceptions
                Console.WriteLine($"Request exception: {e.Message}");
                return false;
            }
        }

        public async Task<bool> Login(UserLoginDto userLogin)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/auth/login", userLogin);
                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadFromJsonAsync<string>();
                    if (token != null)
                    {
                        await _localStorage.SetItemAsync("authToken", token);
                        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                        return true;
                    }
                }
                return false;
            }
            catch (HttpRequestException e)
            {
                // Handle HTTP request exceptions
                Console.WriteLine($"Request exception: {e.Message}");
                return false;
            }
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<bool> IsUserAuthenticated()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            return !string.IsNullOrWhiteSpace(token);
        }
    }

}