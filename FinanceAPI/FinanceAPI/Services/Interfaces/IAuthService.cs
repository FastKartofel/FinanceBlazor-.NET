using FinanceAPI.DAL;

namespace FinanceAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> Register(User user, string password);

        Task<string> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}