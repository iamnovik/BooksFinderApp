using System.Reflection;
using BooksFinderApp.BLL.Services.Implementations;
using BooksFinderApp.BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BooksFinderApp.BLL.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IBookService, BookService>();

        return services;
    }
}