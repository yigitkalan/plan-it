using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using planit.Application.MapProfiles;

namespace planit.Application;
public static class Injection
{
    public static void RegisterApplication(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(c =>
        {
            c.AddProfile<BoardProfile>();
        });
    }

}
