using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Application.Abstractions.Models;
using Core.Application.Interfaces;
using Core.Domain.Entities;
using Core.Domain.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using Attribute = Core.Domain.Entities.Attribute;

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
        private IDictionaryQueryService<TDictionary, TBaseDictionaryDto> _dictionaryQueryServiceImplementation;

        public BaseDictionaryCrudService(
            IAppDbContext dbContext,
            IMapper mapper)
        {
            _mapper = mapper;
            Context = dbContext;
            _dbSet = dbContext.GetDbSet<TDictionary>();
        }

        public async Task<TBaseDictionaryDto[]> GetAll() =>
            await _dbSet.ProjectTo<TBaseDictionaryDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync();

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

        public async Task<TBaseDictionaryDto> GetId(int id)
        {
            var result = await _dbSet.FindAsync(new object[] { id });
            if (result == null) throw new ArgumentNullException();
            return _mapper.Map<TBaseDictionaryDto>(result);
            ;
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