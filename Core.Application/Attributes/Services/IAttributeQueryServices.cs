using System.Threading.Tasks;
using Core.Application.Abstractions;
using Core.Application.Attributes.Models;
using Core.Application.Categories.Models;
using Core.Domain.Entities;

namespace Core.Application.Attributes.Services
{

    public interface IAttributeQueryServices : IDictionaryQueryService<Attribute, AttributeDto>
    {
        Task<AttributeDto> GetId(int id);
    }
}