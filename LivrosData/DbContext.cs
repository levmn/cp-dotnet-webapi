using Microsoft.EntityFrameworkCore;
using LivrosModel;

namespace LivrosData;

public class LivrosDbContext : DbContext
{
    public LivrosDbContext(DbContextOptions<LivrosDbContext> options) : base(options) { }

    public DbSet<LivroModel> Livros { get; set; }
}
