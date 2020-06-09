using DesafioWM.ApplicationService;
using DesafioWM.Domain.AppServices.Anuncio;
using DesafioWM.Domain.AppServices.Authentication;
using DesafioWM.Domain.Notification.Interfaces;
using DesafioWM.Domain.Repository.Anuncio;
using DesafioWM.Domain.Repository.Authentication;
using DesafioWM.Infra.Data;
using DesafioWM.Infra.Repositories.Anuncio;
using DesafioWM.Infra.Repositories.Authentication;
using DesafioWM.Infra.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioWM.API.Helpers
{
    public static class DependencyRegister
    {
        public static void AddScoped(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAnuncioApplicationService, AnuncioApplicationService>();
            services.AddScoped<INotification, NotificadorService>();
            services.AddScoped<IAuthenticationApplicationService, AuthenticationApplicationService>();

            //DB
            services.AddScoped<DataContext, DataContext>();
            services.AddScoped<IAnuncioRepository, AnuncioRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

        }
    }
}
