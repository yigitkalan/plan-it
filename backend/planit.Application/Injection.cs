using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using planit.Application.Bases;
using planit.Application.Behaivors;
using planit.Application.Exceptions;
using planit.Application.MapProfiles;
using planit.Domain.Entities;

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

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient<ExceptionMiddleware>();
        AddRulesFromAssemblyContaining(services, Assembly.GetExecutingAssembly(), typeof(BaseRule));

    }
    public static void ConfigureExceptionHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
    private static void AddRulesFromAssemblyContaining(
           this IServiceCollection services
           , Assembly assembly
           , Type type)
    {
        var types =
            assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(type));

        types.ToList().ForEach(t => services.AddTransient(t));
    }

}
