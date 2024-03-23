using AutoMapper;
using planit.Application.Features;
using planit.Domain.Entities;

namespace planit.Application.MapProfiles;
public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<SignupRequest, User>();
    }
}
