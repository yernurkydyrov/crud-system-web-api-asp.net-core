using System.Threading;
using System.Threading.Tasks;
using Core.Domain.Entities;
using Core.Domain.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Attribute> Attributes { get;  set; }
        DbSet<Category> Categories { get;  set; }
        DbSet<Product> Products { get;  set; }
        DbSet<ProductAttributesValue> ProductAttributeValues { get;  set; } 
        DbSet<CategoryAttribute> CategoryAttributes { get;  set; }
        Task<int> SaveChangesAsync(CancellationToken token);
        DbSet<TEntity> GetDbSet<TEntity>() where TEntity : BaseEntity;
    }
}