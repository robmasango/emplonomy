using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Emplonomy.Model;

namespace Emplonomy.API
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EmplonomyContext>
    {
        public EmplonomyContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<EmplonomyContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new EmplonomyContext(builder.Options);
        }
    }
}
