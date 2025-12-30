using BusinenssLayer.Abstract;
using BusinenssLayer.Concreate;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;


namespace BusinenssLayer.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDal, EFDestinationDal>();

            // ileride:
            // services.AddScoped<IUserService, UserManager>();
            // services.AddScoped<IUserDal, EFUserDal>();

            return services;
        }
    }

}
