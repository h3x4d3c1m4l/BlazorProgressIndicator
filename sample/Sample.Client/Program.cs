using H3x.BlazorProgressIndicator;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sample.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault();
            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddProgressIndicator(options =>
            {
                // don't do this, because the SimpleDemo should demo the default template and all pages share the same IIndicatorService
                //options.IndicatorTemplate = typeof(CustomIndicatorTemplate);
            });

            builder.RootComponents.Add<App>("app");
            await builder.Build().RunAsync();
        }
    }
}
