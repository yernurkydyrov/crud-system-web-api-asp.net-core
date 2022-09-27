using System.Threading.Tasks;
using Core.Application.Categories;
using Core.Application.Categories.Models;
using Core.Application.Categories.Services;
using Core.Application.CategoryAttributes.Web;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Abstractions;

namespace WebApi.Controllers.Dictionary
{
    public class CategoryController : BaseDictionaryController<
        ICategoryQueryService,
        ICategoryCommandService,
        Category,
        CategoryDto>
    {
        public CategoryController(
            ICategoryQueryService queryService,
            ICategoryCommandService commandService) : base(queryService, commandService)
        {
        }

        [HttpPost]
        public async Task<IActionResult> BindCategoryAttribute([FromBody] BindCategoryAttributeRequest request)
        {
            await CommandService.BindCategoryToAttributeAsync(request);
            
            return Ok();
        }  
        

        [HttpDelete]
        public async Task<IActionResult> UnbindCategoryAttribute([FromBody]BoundCategoryAttributeRequest request)
        {
            await QueryService.UnbindCategoryToAttributeAsync(request);
            
            return Ok();
        }   


    }
}