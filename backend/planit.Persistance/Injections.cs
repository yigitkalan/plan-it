using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using planit.Application.Interfaces;
using planit.Domain.Entities;
using planit.Persistance.Contexts;
using planit.Persistance.Getter;
using planit.Persistance.Repository;

namespace planit.Persistance;
public static class Injections
{

    public static void RegisterPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("LiteConnection"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(IRepositoryGetter), typeof(RepositoryGetter));



        services.AddIdentityCore<User>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;
        })
        .AddRoles<Role>().AddEntityFrameworkStores<AppDbContext>();
    }

}
