using Microsoft.AspNetCore.Identity;
using planit.Application.Abstractions;
using planit.Domain.Entities;

namespace planit.Persistance.Services;
public class RoleService
{
    private RoleManager<Role> roleManager;

    public RoleService(RoleManager<Role> roleManager)
    {
        this.roleManager = roleManager;
        
    }
    public async Task AddInitialRoles()
    {
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new Role()
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
        }
        if (!await roleManager.RoleExistsAsync("User"))
        {
            await roleManager.CreateAsync(new Role()
            {
                Id = Guid.NewGuid(),
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
        }
    }
}
