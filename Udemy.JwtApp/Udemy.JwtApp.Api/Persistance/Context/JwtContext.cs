using Microsoft.EntityFrameworkCore;
using Udemy.JwtApp.Api.Core.Domain;
using Udemy.JwtApp.Api.Persistance.Configurations;

namespace Udemy.JwtApp.Api.Persistance.Context
{
    public class JwtContext : DbContext
    {
        public JwtContext(DbContextOptions<JwtContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductCon());
            modelBuilder.ApplyConfiguration(new AppUserCon());
        }
    }
}
