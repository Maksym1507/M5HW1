using M5HW1.Config;
using M5HW1.Dtos;
using M5HW1.Dtos.Requests;
using M5HW1.Dtos.Responses;
using M5HW1.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace M5HW1.Services
{
    public class UserService : IUserService
    {
        private readonly IInternalHttpClientFactory _httpClientFactory;
        private readonly ILogger<UserService> _logger;
        private readonly ApiOption _options;
        private readonly string _userApi = "api/users";

        public UserService(
            IInternalHttpClientFactory httpClientFactory,
            ILogger<UserService> logger,
            IOptions<ApiOption> options)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var result = await _httpClientFactory.SendAsync<BaseResponse<UserDto>, object>(
                $"{_options.Host}{_userApi}/{id}", HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"User with id = {result.Data.Id} was found");
            }

            if (result?.Data == null)
            {
                _logger.LogInformation($"User with id = {id} wasn't found");
            }

            return result?.Data;
        }

        public async Task<UserDto[]> GetUsersByPage(int page)
        {
            var result = await _httpClientFactory.SendAsync<PageBaseResponse<UserDto>, object>(
                $"{_options.Host}{_userApi}?page={page}",
                HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"Users on page = {result.Page} were found");
            }

            return result?.Data;
        }

        public async Task<UserDto[]> GetUsersWithDelay(int delay)
        {
            var result = await _httpClientFactory.SendAsync<PageBaseResponse<UserDto>, object>(
                $"{_options.Host}{_userApi}?delay={delay}", HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"Users were found");
            }

            return result?.Data;
        }

        public async Task<UserResponse> CreateUser(string name, string job)
        {
            var result = await _httpClientFactory.SendAsync<UserResponse, UserRequest>(
                $"{_options.Host}{_userApi}",
                HttpMethod.Post,
                new UserRequest()
                {
                    Job = job,
                    Name = name
                });

            if (result != null)
            {
                _logger.LogInformation($"User with id = {result.Id} was created");
            }

            return result;
        }

        public async Task<UpdateUserResponse> PutUser(int id, string name, string job)
        {
            var result = await _httpClientFactory.SendAsync<UpdateUserResponse, UserRequest>(
                $"{_options.Host}{_userApi}/{id}",
                HttpMethod.Put,
                new UserRequest()
                {
                    Job = job,
                    Name = name,
                });

            if (result != null)
            {
                _logger.LogInformation($"User with name = {result.Name} was updated");
            }

            return result;
        }

        public async Task<UpdateUserResponse> PatchUser(int id, string name, string job)
        {
            var result = await _httpClientFactory.SendAsync<UpdateUserResponse, UserRequest>(
                $"{_options.Host}{_userApi}/{id}",
                HttpMethod.Patch,
                new UserRequest()
                {
                    Job = job,
                    Name = name,
                });

            if (result != null)
            {
                _logger.LogInformation($"User with name = {result.Name} was updated");
            }

            return result;
        }

        public async Task DeleteUser(int id)
        {
            var result = await _httpClientFactory.SendAsync<object, object>(
                $"{_options.Host}{_userApi}/{id}",
                HttpMethod.Delete);

            _logger.LogInformation($"User with id = {id} was deleted");
        }
    }
}
