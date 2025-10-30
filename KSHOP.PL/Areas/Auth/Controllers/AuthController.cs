using KSHOP1.DAL.DTO.Requests;
using KSHOP1.DAL.Models;
using KSHOP1.PL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KSHOP1.PL.Areas.Auth.Controllers
{
    [Area("Auth")]
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtTokenService _jwtTokenService;

        public AuthController(UserManager<ApplicationUser> userManager, JwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "Invalid request data" });
            }

            // Check if user already exists
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return BadRequest(new { message = "User with this email already exists" });
            }

            existingUser = await _userManager.FindByNameAsync(request.UserName);
            if (existingUser != null)
            {
                return BadRequest(new { message = "User with this username already exists" });
            }

            // TODO: Integrate with real user store
            // Create placeholder user
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new { message = "User registration failed", errors = result.Errors });
            }

            return Ok(new { message = "User registered successfully", userId = user.Id });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "Invalid request data" });
            }

            // TODO: Validate credentials with real user store
            // Find user by email or username
            ApplicationUser user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
            }

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            // Validate password
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            // Generate JWT token
            var token = _jwtTokenService.GenerateToken(user.Id, user.UserName, user.Email);

            return Ok(new { token = token });
        }
    }
}
