using H3x.BlazorProgressIndicator;
using Microsoft.AspNetCore.Blazor.Hosting;
using System.Threading.Tasks;

namespace Samples.Template.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault();
            builder.Services.AddLoadingIndicator(true);
            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
