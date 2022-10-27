using Bartarha.Consultation.Core.Interfaces;
using Bartarha.Consultation.Infrastructure.Database;
using Bartarha.Consultation.Infrastructure.Repository;
using Bartarha.Consultation.Infrastructure.Voip;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Bartarha.Consultation.Infrastructure;

public static class Register
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICallService, VoipService>();
        
        services.AddScoped<ICallRepository, CallRepository>();
        
        services.AddDbContext<ApplicationDbContext>(o =>
            o.UseSqlServer(configuration.GetConnectionString("Default")));
        
        FlurlHttp.Configure(settings =>
        {
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ObjectCreationHandling = ObjectCreationHandling.Replace,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };
            settings.JsonSerializer = new NewtonsoftJsonSerializer(jsonSettings);
        });
    }
}