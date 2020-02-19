

using Microsoft.Extensions.DependencyInjection;
using System;

namespace H3x.BlazorProgressIndicator
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddProgressIndicator(this IServiceCollection services, Action<IndicatorOptions> options)
        {
            var _options = new IndicatorOptions();
            options(_options);
            services.AddSingleton<IIndicatorService, IndicatorService>(_ => new IndicatorService
            {
                Options = _options
            });
            return services;
        }
    }
}