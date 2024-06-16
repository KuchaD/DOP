using Microsoft.Extensions.DependencyInjection;

namespace DOP.Abstaction;

public interface IDopOptionsExtension
{
    public void AddServices(IServiceCollection services);
}