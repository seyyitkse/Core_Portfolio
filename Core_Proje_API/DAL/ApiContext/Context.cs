using Core_Proje_API.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje_API.DAL.ApiContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=MSI-BRAVO;database=DbPortfolio;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
