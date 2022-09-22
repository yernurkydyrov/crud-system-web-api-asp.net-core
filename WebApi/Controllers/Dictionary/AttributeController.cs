using System;
using Core.Application.Abstractions;
using Core.Application.Attributes.Models;
using Core.Application.Attributes.Services;
using Core.Application.Categories.Models;
using Core.Domain.Entities;
using WebApi.Controllers.Abstractions;
using Attribute = Core.Domain.Entities.Attribute;

namespace WebApi.Controllers.Dictionary
{
    public class AttributeController : BaseDictionaryController<
        IAttributeQueryServices,
        BaseDictionaryCrudService<Attribute, AttributeDto>,
        Attribute,
        AttributeDto>
    {
        public AttributeController(IDictionaryQueryService<Attribute, AttributeDto> queryService) : base(queryService)
        {
        }
    }
}