using M5HW1.Config;
using M5HW1.Dtos;
using M5HW1.Dtos.Responses;
using M5HW1.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace M5HW1.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IInternalHttpClientFactory _httpClientFactory;
        private readonly ILogger<UserService> _logger;
        private readonly ApiOption _options;
        private readonly string _resourceApi = "api/unknown";

        public ResourceService(
            IInternalHttpClientFactory httpClientFactory,
            ILogger<UserService> logger,
            IOptions<ApiOption> options)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<ResourceDto> GetResourceById(int id)
        {
            var result = await _httpClientFactory.SendAsync<BaseResponse<ResourceDto>, object>(
                $"{_options.Host}{_resourceApi}/{id}", HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"Resource with id = {result.Data.Id} was found");
            }

            if (result?.Data == null)
            {
                _logger.LogInformation($"Resource with id = {id} wasn't found");
            }

            return result?.Data;
        }

        public async Task<ResourceDto[]> GetResources()
        {
            var result = await _httpClientFactory.SendAsync<PageBaseResponse<ResourceDto>, object>(
                $"{_options.Host}{_resourceApi}", HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"Resources on page = {result.Page} were found");
            }

            return result?.Data;
        }
    }
}
