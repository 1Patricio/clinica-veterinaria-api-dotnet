
using Microsoft.EntityFrameworkCore;

// É aqui que vamos dizer que cada módulo vai virar uma tabela no banco
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options) { }

    public DbSet<Tutor> Tutor => Set<Tutor>();
    public DbSet<Pet> Pet => Set<Pet>();
}