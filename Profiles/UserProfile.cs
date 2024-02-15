using AutoMapper;
using Main_Assessment.DTOs;
using Main_Assessment.Entity;

namespace Main_Assessment.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
