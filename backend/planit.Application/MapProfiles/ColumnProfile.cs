using AutoMapper;
using planit.Application.DTOs;
using planit.Application.Features;
using planit.Domain.Entities;

namespace planit.Application.MapProfiles;
public class ColumnProfile: Profile
{
    public ColumnProfile()
    {
        CreateMap<Column, ColumnDto>();
        CreateMap<CreateColumnRequest, Column>();
        CreateMap<UpdateColumnRequest, Column>();
        
    }
}
