using System;
using Core.Application.Abstractions;
using Core.Application.Attributes.Models;
using Core.Domain.Entities;
using WebApi.Controllers.Abstractions;

namespace WebApi.Controllers.Dictionary
{
    public class AttributeController : BaseDictionaryController<
        IDictionaryQueryService<Attributive, AttributeDto>,
        IDictionaryCommandService<Attributive, AttributeDto>,
        Attributive,
        AttributeDto>
    {
        public AttributeController(IDictionaryQueryService<Attributive, AttributeDto> queryService, IDictionaryCommandService<Attributive, AttributeDto> commandService) : base(queryService, commandService)
        {
        }
    }
}