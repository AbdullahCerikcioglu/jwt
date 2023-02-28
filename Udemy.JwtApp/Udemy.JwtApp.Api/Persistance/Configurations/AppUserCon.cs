using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.JwtApp.Api.Core.Domain;

namespace Udemy.JwtApp.Api.Persistance.Configurations
{
    public class AppUserCon : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasOne(x => x.AppRole).WithMany(x => x.AppUsers).HasForeignKey(x => x.AppRoleId);
            //bir rol birden fazla user da olabilr 1 e cok ilişki var.
        }
    }

    public class ProductCon : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        }
    }
}
