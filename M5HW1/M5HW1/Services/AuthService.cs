using M5HW1.Config;
using M5HW1.Dtos.Requests;
using M5HW1.Dtos.Responses;
using M5HW1.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace M5HW1.Services
{
    public class AuthService : IAuthService
    {
        private readonly IInternalHttpClientFactory _httpClientFactory;
        private readonly ILogger<UserService> _logger;
        private readonly ApiOption _options;
        private readonly string _registerApi = "api/register";
        private readonly string _loginApi = "api/login";

        public AuthService(
            IInternalHttpClientFactory httpClientFactory,
            ILogger<UserService> logger,
            IOptions<ApiOption> options)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<AuthResponse> Register(string? email, string? password)
        {
            var result = await _httpClientFactory.SendAsync<AuthResponse, AuthRequest>(
                $"{_options.Host}{_registerApi}",
                HttpMethod.Post,
                new AuthRequest()
                {
                    Email = email,
                    Password = password
                });

            if (result.Token != null)
            {
                _logger.LogInformation($"User was sign up. Token: {result.Token}");
            }

            if (result.Error != null)
            {
                _logger.LogInformation($"Unsuccessful attempt to sign up. Error: {result.Error}");
            }

            return result;
        }

        public async Task<AuthResponse> Login(string? email, string? password)
        {
            var result = await _httpClientFactory.SendAsync<AuthResponse, AuthRequest>(
                $"{_options.Host}{_loginApi}",
                HttpMethod.Post,
                new AuthRequest()
                {
                    Email = email,
                    Password = password
                });

            if (result.Token != null)
            {
                _logger.LogInformation($"User was sign in. Token: = {result.Token}");
            }

            if (result.Error != null)
            {
                _logger.LogInformation($"Unsuccessful attempt to sign in. Error: {result.Error}");
            }

            return result;
        }
    }
}
