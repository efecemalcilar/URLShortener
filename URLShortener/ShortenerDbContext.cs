using Microsoft.EntityFrameworkCore;
using System.Reflection;
using URLShortener.Models;

namespace URLShortener
{
    public class ShortenerDbContext : DbContext
    {
       
        public ShortenerDbContext(DbContextOptions<ShortenerDbContext> options) : base(options)
        {
                
        }

        public virtual DbSet<UrlManagement> Urls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
