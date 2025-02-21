using AutoMapper;
using UsersApp.Models;
using UsersApp.DTOs;

namespace UsersApp.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
