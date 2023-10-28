using Microsoft.EntityFrameworkCore;
using Spotify.Extensions;
using WebApp.Database;
using WebApp.Services;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            // Add database
            services.AddDbContextFactory<JamDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("Default")));

            // Register Spotify services in DI
            services.AddSpotifyAuthentication();
            services.AddSpotifyClient(Configuration);

            // Register app services in DI
            services.AddScoped<GameService>();
            services.AddScoped<TimeZoneService>();
            services.AddSingleton<PlaylistService>();
            services.AddSingleton<SearchService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
