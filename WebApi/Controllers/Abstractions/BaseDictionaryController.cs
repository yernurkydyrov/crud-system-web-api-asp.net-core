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
        BaseDictionaryController<
            TDictionaryQueryService,
            TDictionaryCommandService,
            TDictionary,
            TDictionaryDto> : ControllerBase
        where TDictionary : BaseDictionary
        where TDictionaryDto : BaseDictionaryDto
        where TDictionaryQueryService : IDictionaryQueryService<TDictionary, TDictionaryDto>
        where TDictionaryCommandService : IDictionaryCommandService<TDictionary, TDictionaryDto>
    {
        protected readonly TDictionaryQueryService QueryService;
        protected readonly TDictionaryCommandService CommandService;

        protected BaseDictionaryController(TDictionaryQueryService queryService, TDictionaryCommandService commandService)
        {
            QueryService = queryService;
            CommandService = commandService;
        }
        
        [HttpPost]
        public async Task Create(TDictionaryDto obj) =>
            await CommandService.CreateAsync(obj);

        [HttpGet("{id:int}")]
        public async Task<TDictionaryDto> GetId(int id) => await QueryService.GetId(id);
        
        [HttpPut]
        public async Task<TDictionaryDto> Update(TDictionaryDto dto) =>
            await CommandService.UpdateAsync(dto);

        [HttpDelete]
        public async Task Delete(int id) => 
            await CommandService.DeleteAsync(id);

        [HttpGet]
        public virtual async Task<TDictionaryDto[]> ViewAll() =>
            await QueryService.GetAll();
    }
}