using Data.DataAccessLayer.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Payment.Core.Configurations;
using Payment.Core.Models.ConfigModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment {
    public class Startup {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment) {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Payment", Version = "v1" });
            });
            if (_hostingEnvironment.IsDevelopment()) {
                SqliteConnection inMemorySqlite = new(_configuration.GetConnectionString("DevConnection"));
                inMemorySqlite.Open();

                services.AddDbContext<PaymentAppContext>(options =>
                    options.UseSqlite(inMemorySqlite));
            }

            services.ConfigureAuthService();
            services.ConfigureCookieService();
            services.Configure<LoginConfigModel>(_configuration.GetSection("DevLoginConfig"));

            services.ConfigureBusinessEngines();
            services.ConfigureCoreModules();

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PaymentAppContext context) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            context.Database.Migrate();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
