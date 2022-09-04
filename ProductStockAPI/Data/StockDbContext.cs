using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProductStockAPİ.Models;

namespace ProductStockAPİ.Data
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<ProductStock> ProductStocks { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}