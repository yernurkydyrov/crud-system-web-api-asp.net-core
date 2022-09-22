using System.Threading.Tasks;
using Core.Application.Abstractions.Models;
using Core.Domain.Entities.Abstractions;

namespace Core.Application.Abstractions
{
    public interface IDictionaryCommandService<in TDictionary, TDictionaryDto>
        where TDictionary : BaseDictionary
        where TDictionaryDto : BaseDictionaryDto
    {
        Task<TDictionaryDto> AddAsync(BaseDictionaryDto entity);
        Task UpdateAsync(BaseDictionaryDto entity);
        Task DeleteAsync(int id);
        Task CreateAsync(BaseDictionaryDto dictionaryDto);
    }
}