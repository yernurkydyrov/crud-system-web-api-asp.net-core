using System.Threading.Tasks;
using Core.Application.Abstractions.Models;
using Core.Domain.Entities.Abstractions;

namespace Core.Application.Abstractions
{
    public interface IDictionaryQueryService<TDictionary, TDictionaryDto>
        where TDictionary : BaseDictionary
        where TDictionaryDto : BaseDictionaryDto
    {
        Task<TDictionaryDto[]> GetAll();
    }
}