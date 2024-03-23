using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using planit.Application.Interfaces;
using planit.Domain.Entities;

namespace planit.Application.Bases;
public class BaseHandler
{
    protected readonly IMapper autoMapper;
    protected readonly IRepositoryGetter getter;
    protected readonly IHttpContextAccessor httpContextAccessor;
    protected string userId;

    public BaseHandler(IMapper mapper, IRepositoryGetter repositoryGetter, IHttpContextAccessor httpContextAccessor){
        this.autoMapper = mapper;
        this.getter = repositoryGetter;
        this.httpContextAccessor = httpContextAccessor;
        userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }

}
