using System.Threading.Tasks;
using Core.Application.Abstractions;
using Core.Application.Categories.Models;
using Core.Application.CategoryAttributes.Web;
using Core.Domain.Entities;

namespace Core.Application.Categories.Services
{
    public interface ICategoryCommandService : IDictionaryCommandService<Category, CategoryDto>
    {
         Task BindCategoryToAttributeAsync(BindCategoryAttributeRequest request);
    }
}