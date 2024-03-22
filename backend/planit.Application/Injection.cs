using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace planit.Application;
public static class Injection
{
    public static void RegisterApplication(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }

}
