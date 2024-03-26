using AutoMapper;
using planit.Application.DTOs;
using planit.Application.Features;
using planit.Domain.Entities;

namespace planit.Application.MapProfiles;
public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<SignupRequest, User>();
        CreateMap<User, UserDto>();
    }
}
