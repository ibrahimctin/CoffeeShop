using CoffeeShop.Domain.Application.Profiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace CoffeeShop.Domain.Application.Registrations
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
