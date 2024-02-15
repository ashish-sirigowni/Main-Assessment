using AutoMapper;
using Main_Assessment.DTOs;
using Main_Assessment.Entity;

namespace Main_Assessment.Profiles
{
    public class ConferenceProfile:Profile
    {
        public ConferenceProfile()
        {
            CreateMap<Conference, ConferenceDto>();
            CreateMap<ConferenceDto, Conference>();
        }
    }
}
