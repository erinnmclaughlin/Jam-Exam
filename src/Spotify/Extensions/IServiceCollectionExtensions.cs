using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Spotify.Authentication;
using Spotify.Settings;
using System;

namespace Spotify.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSpotifyClient(this IServiceCollection services, IConfiguration config)
        {
            services.AddRefitClient<IAuthenticationApi>()
                    .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://accounts.spotify.com/api"));

            services.AddRefitClient<ISpotifyApi>()
                    .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://api.spotify.com/v1"))
                    .AddHttpMessageHandler<SpotifyHeaderHandler>();

            services.AddTransient<SpotifyHeaderHandler>();
            services.Configure<SpotifySettings>(config.GetSection("Spotify"));

            return services;
        }
    }
}
