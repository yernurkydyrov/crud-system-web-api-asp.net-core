using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Categories.Abstractions;
using Core.Application.Interfaces;
using Core.Domain.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Categories.Services.Abstractions
{
    public class BaseCrudService<TEntity> : IService<TEntity>
        where TEntity : BaseEntity
    {
        private DbSet<TEntity> _dbSet;

        public BaseCrudService(IAppDbContext dbContext)
        {
            _dbSet = dbContext.GetDbSet<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> View()
        {
            return _dbSet.ToArray();
        }
    }
}