using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductStockAPİ.Models;

namespace ProductStockAPİ.Data.Configurations
{
    public class ProductStockConfiguration : IEntityTypeConfiguration<ProductStock>
    {
        public void Configure(EntityTypeBuilder<ProductStock> builder)
        {
            builder.ToTable("product_stocks");
            builder.HasKey(w => w.Id);
        }
    }
}