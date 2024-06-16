using DOP.Abstaction;
using DOP.Abstaction.Options;
using Microsoft.Extensions.DependencyInjection;

namespace DOP;

public static class DopExtension
{
    public static IServiceCollection AddDop(this IServiceCollection services,  Action<DopOptions> setup)
    {
        services.AddScoped<IDopPublisher, DopPublisher>();
        
        var options = new DopOptions();
        setup(options);
        
        foreach (var serviceExtension in options.Extensions)
            serviceExtension.AddServices(services);
        
        return services;
    }
}