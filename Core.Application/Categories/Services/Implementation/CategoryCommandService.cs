using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Abstractions;
using Core.Application.Categories.Models;
using Core.Application.CategoryAttributes.Web;
using Core.Application.Interfaces;
using Core.Domain.Entities;

namespace Core.Application.Categories.Services.Implementation
{
    
    public class CategoryCommandService : BaseDictionaryCommandService<Category, CategoryDto>, ICategoryCommandService
    {
        public CategoryCommandService(IMapper mapper, IAppDbContext context) : base(mapper, context)
        {
        }
        
        public async Task BindCategoryToAttributeAsync(BindCategoryAttributeRequest request)
        {
            var entity = new CategoryAttribute(request.CategoryId, request.AttributeId);
            
            Context.CategoryAttributes.Add(entity);
            
            await Context.SaveChangesAsync(CancellationToken.None);
        }
    }
}