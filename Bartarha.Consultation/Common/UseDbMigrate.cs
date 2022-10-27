using Bartarha.Consultation.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Bartarha.Consultation.Common;

public static class UseDbMigrate
{
    public static void MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated();
        context.Database.Migrate();
    }
}