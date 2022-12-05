namespace M5HW1.Services.Abstractions
{
    public interface IInternalHttpClientFactory
    {
        Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest content = null)
        where TRequest : class;
    }
}
