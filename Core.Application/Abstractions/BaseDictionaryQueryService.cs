using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Application.Abstractions.Models;
using Core.Application.Interfaces;
using Core.Domain.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Abstractions
{
    public class BaseDictionaryQueryService<TDictionary, TBaseDictionaryDto> :
        IDictionaryQueryService<TDictionary, TBaseDictionaryDto>
        where TDictionary : BaseDictionary
        where TBaseDictionaryDto : BaseDictionaryDto
    {
        private readonly DbSet<TDictionary> _dbSet;
        private readonly IMapper _mapper;

        protected readonly IAppDbContext Context;

        public BaseDictionaryQueryService(
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

        public async Task<TBaseDictionaryDto> GetId(int id)
        {
            var result = await _dbSet.FindAsync(new object[] { id });
            if (result == null) throw new ArgumentNullException();
            return _mapper.Map<TBaseDictionaryDto>(result);
        }
    }
}