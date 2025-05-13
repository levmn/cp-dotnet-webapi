using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using LivrosModel;

namespace LivrosData;

public class DbContextFactory : IDesignTimeDbContextFactory<LivrosDbContext>
{
    public LivrosDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LivrosDbContext>();

        var connectionString = "User Id=rm98276;Password=270401;Data Source=oracle.fiap.com.br:1521/ORCL;";

        optionsBuilder.UseOracle(connectionString);

        return new LivrosDbContext(optionsBuilder.Options);
    }
}
