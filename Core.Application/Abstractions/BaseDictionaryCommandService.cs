using System;
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

        public BaseDictionaryCommandService(IMapper mapper, IAppDbContext context)
        {
            _mapper = mapper;
            Context = context;
            _dbSet = Context.GetDbSet<TDictionary>();
        }
        public async Task<TBaseDictionaryDto> AddAsync(TBaseDictionaryDto dto)
        {
            var entity = _mapper.Map<TDictionary>(dto);
            
            _dbSet.Add(entity);

            await Context.SaveChangesAsync(CancellationToken.None);

            return _mapper.Map<TDictionary, TBaseDictionaryDto>(entity);
        }

        public async Task DeleteAsync(int id)
        { 
            var entity = await _dbSet.FirstOrDefaultAsync(i => i.Id == id);
            _dbSet.Remove(entity);
            await Context.SaveChangesAsync(CancellationToken.None);
        }
        public async Task CreateAsync(TBaseDictionaryDto dictionaryDto)
        {
            var entity = _mapper.Map<TDictionary>(dictionaryDto);
            
            _dbSet.Add(entity);
            await Context.SaveChangesAsync(CancellationToken.None);
        }
        public async Task<TBaseDictionaryDto> UpdateAsync(TBaseDictionaryDto dto)
        {
            var entity = _mapper.Map<TDictionary>(dto);
            if (entity is null)
            {
                throw new InvalidOperationException("Attribute is not found");
            }

            _dbSet.Update(entity);
            await Context.SaveChangesAsync(CancellationToken.None);
            return _mapper.Map<TBaseDictionaryDto>(entity);
        }
    }
}
//Unit
//Integration