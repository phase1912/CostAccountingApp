using CostAccountingApp.ApplicationCore.Interfaces;
using CostAccountingApp.ApplicationCore.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CostAccountingApp.ApplicationCore;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationCore(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DependencyInjection));
        
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        
        services.AddTransient<ICostAccountingService, CostAccountingService>();
        services.Decorate<ICostAccountingService, CostAccountingServiceDecorator>();

        return services;
    }
}