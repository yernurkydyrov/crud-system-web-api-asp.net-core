using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Abstractions;
using Core.Application.Categories.Models;
using Core.Application.Interfaces;
using Core.Domain.Entities;

namespace Core.Application.Categories.Services
{
    public class CategoryService : BaseDictionaryCrudService<Category, CategoryDto>
    {
        public CategoryService(IAppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task BoundAttribute(int categoryId, int attributeId)
        {
            // if (Context.Categories.Any(category => category.Id == categoryId))
            // {
            //     throw new ArgumentException(nameof(categoryId));
            // }
            //
            // if (Context.Attributes.Any(category => category.Id == categoryId))
            // {
            //     throw new ArgumentException(nameof(attributeId));
            // }
            //
            // Context.CategoryAttributes.Add(new CategoryAttribute(categoryId, attributeId));
            //
            // await Context.SaveChangesAsync(default);
        }
    }
}