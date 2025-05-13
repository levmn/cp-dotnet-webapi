using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DotNetEnv;
using LivrosModel;

namespace LivrosData;

public class DbContextFactory : IDesignTimeDbContextFactory<LivrosDbContext>
{
    public LivrosDbContext CreateDbContext(string[] args)
    {
        Env.Load();

        var dbUser = Environment.GetEnvironmentVariable("DB_USER");
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
        var dbService = Environment.GetEnvironmentVariable("DB_SERVICE");

        var connectionString = $"User Id={dbUser};Password={dbPassword};Data Source={dbHost}:{dbPort}/{dbService};";

        var optionsBuilder = new DbContextOptionsBuilder<LivrosDbContext>();
        optionsBuilder.UseOracle(connectionString);

        return new LivrosDbContext(optionsBuilder.Options);
    }
}
