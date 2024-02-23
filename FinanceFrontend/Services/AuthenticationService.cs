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
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error during registration: {error}");
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


        // Updated to include redirection logic
        public async Task<(bool Success, string Message, string RedirectTo)> Login(UserLoginDto userLogin)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/auth/login", userLogin);
                if (response.IsSuccessStatusCode)
                {
                    var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                    var token = loginResponse.Token;
                    await _localStorage.SetItemAsync("authToken", token);
                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    return (true, "Login successful", "/plan"); // Use the RedirectTo property if needed
                }
                else
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    return (false, errorResponse, null);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException during login: {e.Message}");
                return (false, $"HTTP request error: {e.Message}", null);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception during login: {e.Message}");
                return (false, $"An error occurred during login: {e.Message}", null);
            }
        }

    }
}