using M5HW1.Dtos.Responses;

namespace M5HW1.Services.Abstractions
{
    public interface IAuthService
    {
        Task<AuthResponse> Register(string? email, string? password);

        Task<AuthResponse> Login(string? email, string? password);
    }
}
