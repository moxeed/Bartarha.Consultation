using Bartarha.Consultation.Core.Interfaces;
using Bartarha.Consultation.Infrastructure.Database;
using Bartarha.Consultation.Infrastructure.Voip;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bartarha.Consultation.Infrastructure;

public static class Register
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICallService, VoipService>();
        services.AddDbContext<ApplicationDbContext>(o =>
            o.UseSqlServer(configuration.GetConnectionString("Default")));
    }
}