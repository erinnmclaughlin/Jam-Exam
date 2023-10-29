using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Spotify.Authentication;
using Spotify.Settings;
using System;

namespace Spotify.Extensions;

public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Registers required services for authenticating against the Spotify API
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddSpotifyAuthentication(this IServiceCollection services)
    {
        services.AddRefitClient<ISpotifyAuthClient>()
                .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://accounts.spotify.com/api"));

        services.AddSingleton<TokenService>();
        services.AddTransient<SpotifyHeaderHandler>();

        return services;
    }

    /// <summary>
    /// Adds required services for using the Spotify client
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IServiceCollection AddSpotifyClient(this IServiceCollection services, IConfiguration config)
    {
        services.AddRefitClient<ISpotifyClient>()
                .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://api.spotify.com/v1"))
                .AddHttpMessageHandler<SpotifyHeaderHandler>();

        services.Configure<SpotifySettings>(config.GetSection("Spotify"));

        return services;
    }
}
