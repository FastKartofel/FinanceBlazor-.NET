using FinanceAPI.DAL;
using FinanceAPI.DTO;
using FinanceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FinanceAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly FinanceDbContext _context;

        public AuthController(IAuthService authService, FinanceDbContext context)
        {
            _authService = authService;
            _context = context;
        }

        //just for checking user data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDTO>>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            return Ok(users);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO userDto)
        {
            if (await _context.Users.AnyAsync(x => x.Username == userDto.Username))
            {
                return BadRequest("Username is already taken");
            }

            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email
                // PasswordHash and PasswordSalt will be set within the AuthService
            };

            var createdUser = await _authService.Register(user, userDto.Password);

            if (createdUser == null)
            {
                return BadRequest("Could not create user");
            }

            var userResponse = new UserResponseDTO
            {
                UserId = createdUser.UserId,
                Username = createdUser.Username,
                Email = createdUser.Email
            };

            return StatusCode(201, userResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {
            var token = await _authService.Login(loginDto.Username, loginDto.Password);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Invalid username or password");
            }

            return Ok(new { token = token });
        }
    }
}