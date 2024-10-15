using BooksFinderApp.DAL.Repositories.Implementations;
using BooksFinderApp.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace BooksFinderApp.DAL.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient();
        services.AddScoped<IGoogleApiService, GoogleApiService>();
        return services;
    }
}