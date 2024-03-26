using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using planit.Application.Abstractions;
using planit.Domain.Entities;

namespace planit.Application.Bases;
public class BaseHandler
{
    protected readonly IMapper mapper;
    protected readonly IRepositoryGetter getter;
    protected readonly IHttpContextAccessor httpContextAccessor;
    protected string userId;

    public BaseHandler(IMapper mapper, IRepositoryGetter getter, IHttpContextAccessor httpContextAccessor){
        this.mapper = mapper;
        this.getter = getter;
        this.httpContextAccessor = httpContextAccessor;
        userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }

}
