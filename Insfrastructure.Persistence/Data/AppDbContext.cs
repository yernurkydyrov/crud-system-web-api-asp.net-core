using Core.Application.Interfaces;
using Core.Domain.Entities;
using Core.Domain.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Insfrastructure.Persistance.Data
{
    
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Attributive> Attributes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttributesValue> ProductAttributeValues { get; set; }
        public DbSet<CategoryAttribute> CategoryAttributes { get; set; }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : BaseEntity =>
            Set<TEntity>();

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
    }
}