using AutoMapper;
using CoVoyageur.API.DTOs;
using CoVoyageur.Core.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoVoyageur.API.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Ride, RideDTO>().ReverseMap();
        }   
    }
}
