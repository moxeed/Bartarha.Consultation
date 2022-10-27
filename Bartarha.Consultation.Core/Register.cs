using Bartarha.Consultation.Core.Call;
using Microsoft.Extensions.DependencyInjection;

namespace Bartarha.Consultation.Core;

public static class Register
{
    public static void AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<CallService>();
        services.AddHostedService<CallScheduler>();
    }
}