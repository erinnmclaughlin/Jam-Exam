using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Client.Authentication;
using Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddScoped<AuthenticationStateProvider, JamExamAuthStateProvider>();
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<GameManager>();
            builder.Services.AddTransient<JamHeaderHandler>();

            builder.Services.AddRefitClient<IJamApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api"))
                .AddHttpMessageHandler<JamHeaderHandler>();

            await builder.Build().RunAsync();
        }
    }
}
