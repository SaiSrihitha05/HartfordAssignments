using Application.DTOs;
using Application.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApiWithDb.InterfaceAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(result);
        }
        [HttpGet("get-captcha")]
        public IActionResult GetCaptcha()
        {
            // Generate a random 6-character string
            string code = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();

            // In a real app, store this in MemoryCache or Session to verify later
            // For now, we return it to display
            return Ok(new { captchaCode = code });
        }
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var token = await _authService.CreatePasswordResetTokenAsync(dto.Email);

            if (token == null)
            {
                return BadRequest(new { message = "User not found." });
            }

            // Return the token to the frontend
            return Ok(new { token = token });
        }
        [HttpPost("reset-password")] // This creates the /api/Auth/reset-password route
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            // Call your service here
            var result = await _authService.ResetPasswordAsync(dto);

            if (!result)
            {
                return BadRequest(new { message = "Invalid or expired reset link." });
            }

            return Ok(new { message = "Password has been reset successfully." });
        }
    }
        
}