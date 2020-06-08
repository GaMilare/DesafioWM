using DesafioWM.API.Helpers;
using DesafioWM.ApplicationService;
using DesafioWM.Domain.AppServices.Anuncio;
using DesafioWM.Domain.Notification.Interfaces;
using DesafioWM.Infra.Data;
using DesafioWM.Infra.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DesafioWM.API
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
            services.AddCors();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Desafio Web Motors",
                    Description = "Desafio: Criar um crud de anúncios, integrando com as camadas propostas no pdf do desafio (http://desafioonline.webmotors.com.br/).",
                    Contact = new OpenApiContact() { Name = "Gabriel Milaré de Paula - 11 947240633", Email = "gmilare@outlook.com" },
                    Version = "v1"
                });
            });

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            ConfigureDI(services, Configuration);
        }

        public static void ConfigureDI(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            DependencyRegister.AddScoped(services, configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio Web Motors");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
