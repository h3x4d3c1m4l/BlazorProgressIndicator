

using Microsoft.Extensions.DependencyInjection;

namespace H3x.BlazorProgressIndicator
{
    public static class Extensions
    {
        public static IServiceCollection AddLoadingIndicator(this IServiceCollection services, bool dumpExceptionsToConsole = false)
        {
            services.AddSingleton<ILoadingService, LoadingService>(_ => new LoadingService
            {
                DumpExceptionsToConsole = dumpExceptionsToConsole
            });
            return services;
        }
    }
}