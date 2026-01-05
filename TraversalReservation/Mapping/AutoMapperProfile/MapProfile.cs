using AutoMapper;
using DTOLayers.DTOs.AnnouncementDTOs;
using DTOLayers.DTOs.AppUserDTOs;
using EntityLayer.Concreate;

namespace TraversalReservation.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementDTO, Announcement>().ReverseMap();
            CreateMap<AppUserLoginDTO, AppUser>().ReverseMap();
            CreateMap<AppUserRegisterDTO, AppUser>().ReverseMap();
        }
    }
}
