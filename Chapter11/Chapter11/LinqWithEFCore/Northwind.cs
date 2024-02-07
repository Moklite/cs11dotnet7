using Microsoft.EntityFrameworkCore; // DbContext, DbSet<T>
namespace Packt.Shared;
public class Northwind : DbContext
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    protected override void OnConfiguring(
    DbContextOptionsBuilder optionsBuilder)
    {

        string connection = $"Data Source=;Initial Catalog=Northwind;Integrated Security=True;TrustServerCertificate=True";
        optionsBuilder.UseSqlServer(connection);
        
    }
    protected override void OnModelCreating(
    ModelBuilder modelBuilder)
    {
        if ((Database.ProviderName is not null)
        && (Database.ProviderName.Contains("Sqlite")))
        {
            modelBuilder.Entity<Product>()
            .Property(product => product.UnitPrice)
            .HasConversion<double>();
        }
    }
}
