using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Abstractions.Models;
using Core.Application.Interfaces;
using Core.Domain.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Abstractions
{
    public class BaseDictionaryCommandService<TDictionary, TBaseDictionaryDto> :
        IDictionaryCommandService<TDictionary, TBaseDictionaryDto>
        where TDictionary : BaseDictionary
        where TBaseDictionaryDto : BaseDictionaryDto
    {
        private readonly DbSet<TDictionary> _dbSet;
        private readonly IMapper _mapper;

        protected readonly IAppDbContext Context;
        
        // public async Task<TBaseDictionaryDto> AddAsync(TDictionary dto)
        // {
        //  
        // }

        // public async Task UpdateAsync(TBaseDictionaryDto entity)
        // {
        //     _dbSet.Update(entity);
        //
        //     await Context.SaveChangesAsync(CancellationToken.None);
        // }

        public async Task<TBaseDictionaryDto> AddAsync(BaseDictionaryDto dto)
        {
            var entity = _mapper.Map<TDictionary>(dto);
            
            _dbSet.Add(entity);

            await Context.SaveChangesAsync(CancellationToken.None);

            return _mapper.Map<TDictionary, TBaseDictionaryDto>(entity);
        }

        public Task UpdateAsync(BaseDictionaryDto entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(new[] { id });

            _dbSet.Remove(entity);

            await Context.SaveChangesAsync(CancellationToken.None);
        }

        public Task CreateAsync(BaseDictionaryDto dictionaryDto)
        {
            throw new System.NotImplementedException();
        }

        public async Task CreateAsync(TBaseDictionaryDto dto)
        {
            var entity = _mapper.Map<TDictionary>(dto);
            
            _dbSet.Add(entity);
            await Context.SaveChangesAsync(CancellationToken.None);
        }
        
        public async Task<TBaseDictionaryDto> UpdateAsync(TBaseDictionaryDto dto)
        {
            var entity = _mapper.Map<TDictionary>(dto);
            _dbSet.Update(entity);
            await Context.SaveChangesAsync(CancellationToken.None);
            return _mapper.Map<TBaseDictionaryDto>(entity);
        }
    }
}