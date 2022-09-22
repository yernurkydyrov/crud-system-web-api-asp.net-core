using Core.Application.Abstractions;
using Core.Application.Categories.Models;
using Core.Application.Categories.Services;
using Core.Domain.Entities;
using WebApi.Controllers.Abstractions;

namespace WebApi.Controllers.Dictionary
{
    public class CategoryController : BaseDictionaryController<
        ICategoryQueryService,
        BaseDictionaryCrudService<Category, CategoryDto>,
        Category,
        CategoryDto>
    {
        public CategoryController(
            IDictionaryQueryService<Category, CategoryDto> queryService) : base(queryService)
        {
        }
        
        /*public async Task<TDictionaryDto[]> ViewAllAttribute() =>
    await QueryService.GetAll();

[HttpGet("attributes/{id:int}")]
public async Task<TDictionaryDto> GetIdAttribute(int id) => await QueryService.GetId(id);

public async Task<TDictionaryDto> UpdateCategory(Category category) =>
    await QueryService.UpdateCategory(category);*/

        /*public async Task<CategoryDto[]> ViewAllCategory() => await QueryService.GetAll();
        
        [HttpGet("category/{id:int}")] 
        public async Task<CategoryDto> GetIdCategory(int id) => await QueryService.GetId(id);

        public async Task<CategoryDto> UpdateCategory(CategoryDto category) =>
            await QueryService.UpdateAsync(category);

        public async void DeleteCategory(int id) => await QueryService.DeleteAsync(id);*/
    }
}