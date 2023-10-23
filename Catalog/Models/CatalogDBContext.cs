using Microsoft.EntityFrameworkCore;

namespace Catalog.Models
{
    public class CatalogDBContext : DbContext
    {
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Adresa> Adrese { get; set; }
        public CatalogDBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\source\repos\lab19\Catalog\Catalog.mdf;Integrated Security=True");
        }
    }
}
