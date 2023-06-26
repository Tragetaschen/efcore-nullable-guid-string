using Microsoft.EntityFrameworkCore;

namespace efcore_nullable_guid_string;

public class MyDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=efcorenullableguidstring;Trusted_Connection=True");
        optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
    }

    
    public DbSet<MyEntity> MyEntities { get; set; } = null!;
}