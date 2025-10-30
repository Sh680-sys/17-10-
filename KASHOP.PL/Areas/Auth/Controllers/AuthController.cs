using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using KASHOP.DAL.DTO.Requests;
using KASHOP.PL.Services;

namespace KASHOP.PL.Areas.Auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _jwtService;

        // TODO: inject your real user service/repository (IUserService) to handle create/validate users
        public AuthController(JwtTokenService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // TODO: integrate with user store: hash password, save user, check duplicates
            return Created("", new { message = "User created (placeholder). Integrate with user store." });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // TODO: validate credentials against real user store (compare hashed passwords)
            if (string.IsNullOrWhiteSpace(request.UserNameOrEmail) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest(new { message = "Invalid credentials" });

            // Example: replace userId and role with real values from the user store after validation
            var token = _jwtService.GenerateToken(userId: "1", userName: request.UserNameOrEmail, role: "Customer");
            return Ok(new { token });
        }
    }
}