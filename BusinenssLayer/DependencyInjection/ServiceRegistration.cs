using BusinenssLayer.Abstract;
using BusinenssLayer.Concreate;
using BusinenssLayer.Validations;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DTOLayers.DTOs.AnnouncementDTOs;
using FluentValidation;
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
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EFCommentDal>();

            //Reservation
            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EFReservationDal>();

            //Guide
            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EFGuideDal>();

            //ContactUs
            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal, EFContactUsDal>();

            //Announcement
            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EFAnnouncementDal>();

            return services;
        }

        public static void CustomerValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AnnouncementDTO>, AnnouncementValidations>();
        }
    }

}
