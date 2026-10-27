using JobTrackerApi.DTOs;

namespace JobTrackerApi.Services;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterDto registerDto);
    Task<string> LoginAsync(LoginDto loginDto);
}