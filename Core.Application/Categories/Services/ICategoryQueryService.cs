using Core.Application.Abstractions;
using Core.Application.Categories.Models;
using Core.Domain.Entities;

namespace Core.Application.Categories.Services
{
    public interface ICategoryQueryService : IDictionaryQueryService<Category, CategoryDto>
    {
    }
}