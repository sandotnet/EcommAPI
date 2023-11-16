using AutoMapper;
using EcommAPI.DTOs;
using EcommAPI.Entities;

namespace EcommAPI.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto,User>();
        }
    }
}
