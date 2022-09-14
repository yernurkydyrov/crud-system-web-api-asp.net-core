using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Abstractions.Models;
using Core.Application.Interfaces;
using Core.Domain.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Abstractions
{
    public class BaseDictionaryCrudService<TDictionary, TBaseDictionaryDto> :
        IDictionaryQueryService<TDictionary, TBaseDictionaryDto>,
        IDictionaryCommandService<TDictionary, TBaseDictionaryDto>
        where TDictionary : BaseDictionary
        where TBaseDictionaryDto : BaseDictionaryDto
    {
        private readonly DbSet<TDictionary> _dbSet;
        private readonly IMapper _mapper;

        protected readonly IAppDbContext Context;
        
        public BaseDictionaryCrudService(
            IAppDbContext dbContext,
            IMapper mapper)
        {
            _mapper = mapper;
            Context = dbContext;
            _dbSet = dbContext.GetDbSet<TDictionary>();
        }

        public async Task<TBaseDictionaryDto[]> GetAll() =>
            _mapper.Map<TDictionary[], TBaseDictionaryDto[]>(_dbSet.ToArray());

        public async Task<TBaseDictionaryDto> AddAsync(TDictionary entity)
        {
            _dbSet.Add(entity);

            await Context.SaveChangesAsync(CancellationToken.None);

            return _mapper.Map<TDictionary, TBaseDictionaryDto>(entity);
        }

        public async Task UpdateAsync(TDictionary entity)
        {
            _dbSet.Update(entity);

            await Context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(new[] { id });
            
            _dbSet.Remove(entity);

            await Context.SaveChangesAsync(CancellationToken.None);
        }
    }
}