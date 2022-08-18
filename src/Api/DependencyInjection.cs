using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Services;
namespace Api;

public static class DependencyInjection
{
    public static void AddRepositories(this IServiceCollection repositories)
    {
        repositories.AddScoped<PeopleRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<PeopleService>();
    }

}
