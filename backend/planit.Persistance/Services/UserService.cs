using Microsoft.AspNetCore.Identity;
using planit.Application.Abstractions;
using planit.Domain.Entities;

namespace planit.Persistance.Services;
public class UserService
{
    private UserManager<User> userManager;

    public UserService(UserManager<User> userManager)
    {
        this.userManager = userManager;
        
    }
    public async Task AddInitialAdmin()
    {
        string email = "admin@admin.com";
        string Password = "Admin123@";
        if(await userManager.FindByEmailAsync(email) == null)
        {
            User user = new User()
            {
                Email = email,
                UserName = email,
                EmailConfirmed = true
            };
            await userManager.CreateAsync(user, Password);
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
