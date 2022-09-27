using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Abstractions;
using Core.Application.Categories.Models;
using Core.Application.CategoryAttributes.Web;
using Core.Application.Interfaces;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Categories.Services.Implementation
{
    public class CategoryQueryService : BaseDictionaryQueryService<Category,CategoryDto>, ICategoryQueryService
    {
        
        public CategoryQueryService(IAppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task UnbindCategoryToAttributeAsync(BoundCategoryAttributeRequest request)
        {
            if (request.CategoryId == null)
            {
                throw new ArgumentException("Category id cannot be null");
            }

            if (request.AttributeId == null)
            {
                throw new ArgumentException("Attribute id cannot be null");
            }

            var entity = await Context.CategoryAttributes.FirstOrDefaultAsync(i => i.CategoryId  == request.CategoryId && i.AttributeId == request.AttributeId, CancellationToken.None);
            if (entity == null)
            {
                throw new InvalidOperationException("Category attribute not found");
            }
            
            Context.CategoryAttributes.Remove(entity);


            await Context.SaveChangesAsync(CancellationToken.None);
        }
        
        

        
        /*TODO::
        GetAttributesByCategoryId
        
         Unbind
        */


    }
}