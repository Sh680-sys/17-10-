using KSHOP.PL.Services;
using KSHOP1.DAL.DTO.Requests;
using KSHOP1.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KSHOP1.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtTokenService _jwtTokenService;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            JwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "Invalid registration request" });
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

            // Create new user
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

            return CreatedAtAction(nameof(Register), new { email = user.Email }, new { message = "User registered successfully", userId = user.Id });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "Invalid login request" });
            }

            // Find user by email or username
            var user = await _userManager.FindByEmailAsync(request.UserNameOrEmail) 
                ?? await _userManager.FindByNameAsync(request.UserNameOrEmail);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            // Check password
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            // Generate JWT token
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenService.GenerateToken(user.Id, user.UserName!, user.Email!, roles);

            return Ok(new { token = token });
        }
    }
}
