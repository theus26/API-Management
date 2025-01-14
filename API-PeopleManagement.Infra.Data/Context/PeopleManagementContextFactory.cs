using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace API_PeopleManagement.Infra.Data.Context;

public class PeopleManagementContextFactory : IDesignTimeDbContextFactory<PeopleManagementContext>
{
  
    PeopleManagementContext IDesignTimeDbContextFactory<PeopleManagementContext>.CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../API-PeopleManagement");

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<PeopleManagementContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseNpgsql(connectionString);

        return new PeopleManagementContext(optionsBuilder.Options);
    }
}