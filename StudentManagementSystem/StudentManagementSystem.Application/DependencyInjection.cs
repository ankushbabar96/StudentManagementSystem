using Microsoft.Extensions.DependencyInjection;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Application.Services;

namespace StudentManagementSystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();
        return services;
    }
}

