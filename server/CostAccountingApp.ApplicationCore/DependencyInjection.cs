using Microsoft.Extensions.DependencyInjection;

namespace CostAccountingApp.ApplicationCore;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationCore(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DependencyInjection));
        
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        return services;
    }
}