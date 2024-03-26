using AutoMapper;
using planit.Application.DTOs;
using planit.Application.Features;
using planit.Domain.Entities;

namespace planit.Application.MapProfiles;
public class BoardProfile: Profile
{
    public BoardProfile()
    {
        CreateMap<Board, BoardDto>();
        CreateMap<CreateBoardRequest, Board>();
        CreateMap<UpdateBoardRequest, Board>();
        
    }

}
