using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Server.Authentication;
using Server.Data;
using Server.Services;
using Server.Settings;
using System;
using System.Net.Http;

namespace Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<JamContext>(x => x.UseSqlServer(Configuration.GetConnectionString("JamExam")));
            services.AddHttpClient("Spotify", x => x.BaseAddress = new Uri("https://api.spotify.com/v1/"));
            services.AddHttpContextAccessor();
            services.AddScoped<CurrentUserService>();
            services.AddScoped<TokenManager>();
            services.Configure<SpotifySettings>(Configuration.GetSection("Spotify"));
            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
