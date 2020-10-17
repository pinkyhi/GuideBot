using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuideBot.BL.Bots;
using GuideBot.Core.Options;
using GuideBot.DAL.Contexts;
using GuideBot.DAL.Interfaces;
using GuideBot.DAL.Repositories;
using GuideBot.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GuideBot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Порядок не важен
        public void ConfigureServices(IServiceCollection services)
        {
            this.InstallDataAccess(services);
            this.InstallBot(services);
            this.InstallFilters(services);
            services.AddControllers().AddNewtonsoftJson();
        }

        // Порядок важен
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.ApplicationServices.GetService<GuideBotClient>();
        }

        private void InstallDataAccess(IServiceCollection services)
        {
            string connection = this.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(connection);
            });
            services.AddScoped<IRepository, Repository>();
        }

        private void InstallBot(IServiceCollection services)
        {
            GuideBotOptions guideBotOptions = new GuideBotOptions();
            this.Configuration.GetSection("GuideBot").Bind(guideBotOptions);
            services.AddSingleton(guideBotOptions);
            services.AddSingleton<GuideBotClient>();
        }

        private void InstallFilters(IServiceCollection services)
        {
            services.AddScoped<GuideBotExceptionFilterAttribute>();
        }
    }
}
