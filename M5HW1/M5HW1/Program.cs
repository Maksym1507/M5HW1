using M5HW1.Config;
using M5HW1.Services;
using M5HW1.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace M5HW1
{
    internal class Program
    {
        private static void ConfigurationServices(ServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOptions<ApiOption>().Bind(configuration.GetSection("Api"));

            serviceCollection
                .AddLogging(configure => configure.AddConsole())
                .AddHttpClient()
                .AddTransient<IInternalHttpClientFactory, InternalHttpClientFactory>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IResourceService, ResourceService>()
                .AddTransient<IAuthService, AuthService>()
                .AddTransient<App>();
        }

        private static async Task Main()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            var serviceCollection = new ServiceCollection();
            ConfigurationServices(serviceCollection, configuration);
            var provider = serviceCollection.BuildServiceProvider();

            var app = provider.GetService<App>();
            await app!.Start();
        }
    }
}