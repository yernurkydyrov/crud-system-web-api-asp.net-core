using System.Threading.Tasks;
using Core.Application.Abstractions;
using Core.Application.Abstractions.Models;
using Core.Domain.Entities.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Abstractions
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class
        BaseDictionaryController<TService, TQueryService, TDictionary, TDictionaryDto> : ControllerBase
        where TDictionary : BaseDictionary
        where TDictionaryDto : BaseDictionaryDto
        where TService : IDictionaryQueryService<TDictionary, TDictionaryDto>
        where TQueryService : IDictionaryCommandService<TDictionary, TDictionaryDto>
    {
        private readonly IDictionaryQueryService<TDictionary, TDictionaryDto> _dictionaryQueryService;

        protected BaseDictionaryController(IDictionaryQueryService<TDictionary, TDictionaryDto> dictionaryQueryService)
        {
            _dictionaryQueryService = dictionaryQueryService;
        }

        public async Task<TDictionaryDto[]> ViewAll() =>
            await _dictionaryQueryService.GetAll();
    }
}