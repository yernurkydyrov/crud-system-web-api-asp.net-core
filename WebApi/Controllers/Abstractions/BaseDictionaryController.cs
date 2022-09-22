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
        BaseDictionaryController<TDictionaryQueryService, TDictionaryCommandService, TDictionary, TDictionaryDto> : ControllerBase
        where TDictionary : BaseDictionary
        where TDictionaryDto : BaseDictionaryDto
        where TDictionaryQueryService : IDictionaryQueryService<TDictionary, TDictionaryDto>
        where TDictionaryCommandService : IDictionaryCommandService<TDictionary, TDictionaryDto>
    {
        protected readonly IDictionaryQueryService<TDictionary, TDictionaryDto> QueryService;

        protected BaseDictionaryController(IDictionaryQueryService<TDictionary, TDictionaryDto> queryService)
        {
            QueryService = queryService;
            
            
        }

        [HttpGet]
        public virtual async Task<TDictionaryDto[]> ViewAll() =>
            await QueryService.GetAll();

        [HttpGet("{id:int}")]
        public async Task<TDictionaryDto> GetId(int id) => await QueryService.GetId(id);
        
        [HttpPut]
        public async Task<TDictionaryDto> Update(TDictionaryDto dto) =>
            await QueryService.UpdateAsync(dto);

        [HttpDelete]
        public async Task Delete(int id) => await QueryService.DeleteAsync(id);


    }
}