using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RouletteService.Controllers;
using RouletteService.Database;
using RouletteService.Repositories;
using RouletteService.Services;
using RouteService.Controllers;

namespace RouletteService
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

            services.AddSingleton(new DatabaseConfig { Name = Configuration["DatabaseName"] });

            services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();
            services.AddSingleton<IGameRepository, GameRepository>();
            services.AddSingleton<IGameService, GameService>();
            services.AddSingleton<IPlayerRepository, PlayerRepository>();
            services.AddSingleton<IPlayerService, PlayerService>();
            services.AddSingleton<IBetRepository, BetRepository>();
            services.AddSingleton<IBetService, BetService>();
            services.AddSingleton<ISpinRepository, SpinRepository>();
            services.AddSingleton<ISpinService, SpinService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            IServiceProvider serviceProvider)
        {


            app.ErrorHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            serviceProvider.GetService<IDatabaseBootstrap>().Setup();


        }
    }
}
