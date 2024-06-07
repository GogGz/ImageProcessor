using CommonCross.Helpers;
using CommonCross.ServiceRegistrations.DependencyInjection;
using IP.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace IP.Persistence
{
    public class BaseDbContext : DbContext, IScoped
    {
        public BaseDbContext()
        {
        }

        public BaseDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public void ApplyAllConfigurations(ModelBuilder modelBuilder)
        {
            string currentClassName = GetType().Name;
            var typesToRegister = AssemblyDetail.FromAssembliesInSearchPath("IP.Persistence")
                                            .Where(type => type.GetTypeInfo().BaseType == typeof(EntityConfiguration));

            foreach (var type in typesToRegister)
            {
                Activator.CreateInstance(type, modelBuilder);
            }
        }
    }
}
