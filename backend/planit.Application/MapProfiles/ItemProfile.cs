using AutoMapper;
using planit.Application.DTOs;
using planit.Application.Features;
using planit.Domain.Entities;

namespace Namespace;
public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<Item, ItemDto>();
        CreateMap<CreateItemRequest, Item>();
    }

}
