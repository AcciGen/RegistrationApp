using Microsoft.Extensions.DependencyInjection;
using RegistrationApp.Application.Services.LoginServices;

namespace RegistrationApp.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();

            return services;
        }
    }
}
