using Microsoft.Extensions.DependencyInjection;

namespace Localstack.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(options =>
            {
                options.Lifetime = ServiceLifetime.Scoped;
            });

            return services;
        }
    }
}
