

using Microsoft.Extensions.DependencyInjection;

namespace H3x.BlazorProgressIndicator
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddLoadingIndicator(this IServiceCollection services, bool dumpExceptionsToConsole = false)
        {
            services.AddSingleton<IIndicatorService, IndicatorService>(_ => new IndicatorService
            {
                DumpExceptionsToConsole = dumpExceptionsToConsole
            });
            return services;
        }
    }
}