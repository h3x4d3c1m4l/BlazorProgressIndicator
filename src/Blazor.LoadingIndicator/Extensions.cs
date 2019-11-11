

using Microsoft.Extensions.DependencyInjection;

namespace Blazor.LoadingIndicator
{
    public static class Extensions
    {   
        public static IServiceCollection AddLoadingIndicator(this IServiceCollection services)
        {
            services.AddSingleton<ILoadingService, LoadingService>();
            return services;
        }
    }
}