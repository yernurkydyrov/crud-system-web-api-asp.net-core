using AutoMapper;
using Core.Application.Abstractions;
using Core.Application.Attributes.Models;
using Core.Application.Categories.Models;
using Core.Application.Interfaces;
using Core.Domain.Entities;

namespace Core.Application.Attributes.Services
{
    public class AttributeService : BaseDictionaryQueryService<Attribute, AttributeDto>
    {
        public AttributeService(IAppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}