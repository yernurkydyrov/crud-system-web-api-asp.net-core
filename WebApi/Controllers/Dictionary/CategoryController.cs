using Core.Application.Abstractions;
using Core.Application.Categories.Models;
using Core.Domain.Entities;
using WebApi.Controllers.Abstractions;

namespace WebApi.Controllers.Dictionary
{
    public class CategoryController : BaseDictionaryController<
        BaseDictionaryCrudService<Category, CategoryDto>,
        BaseDictionaryCrudService<Category, CategoryDto>,
        Category,
        CategoryDto>
    {
        public CategoryController(IDictionaryQueryService<Category, CategoryDto> dictionaryQueryService) : base(dictionaryQueryService)
        {
        }
    }
}