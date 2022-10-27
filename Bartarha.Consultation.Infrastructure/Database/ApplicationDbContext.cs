using System.Reflection;
using Bartarha.Consultation.Core.Common;
using Microsoft.EntityFrameworkCore;

namespace Bartarha.Consultation.Infrastructure.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var type = typeof(Entity);
        var entities =type.Assembly.GetTypes().Where(T => typeof(Entity).IsAssignableFrom(T));

        foreach (var entity in entities)
        {
            modelBuilder.Entity(entity).ToTable(entity.Name);
        }
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}