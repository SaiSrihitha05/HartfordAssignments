using Application.DTOs;

namespace Application.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
        Task<string?> CreatePasswordResetTokenAsync(string email);
        Task<bool> ResetPasswordAsync(ResetPasswordDto dto);
    }
}