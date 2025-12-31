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
            //Destination
            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDal, EFDestinationDal>();

            //Comments
            services.AddScoped<ICommentService, CommentManager> ();
            services.AddScoped<ICommentDal, EFCommentDal>();

            //Reservation
            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EFReservationDal>();

            //Guide
            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EFGuideDal>();
            return services;
        }
    }

}
