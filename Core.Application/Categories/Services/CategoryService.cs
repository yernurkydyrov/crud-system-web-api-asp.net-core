using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Categories.Services.Abstractions;
using Core.Application.Interfaces;
using Core.Domain.Entities;

namespace Core.Application.Categories.Services
{
    public class CategoryService : BaseCrudService<Category>
    {
        public CategoryService(IAppDbContext dbContext) : base(dbContext)
        {
        }

        private readonly IAppDbContext _context;

        public async Task BoundAttribute(int categoryId, int attributeId)
        {
            if (_context.Categories.Any(category => category.Id == categoryId))
            {
                throw new ArgumentException(nameof(categoryId));
            }

            if (_context.Attributes.Any(category => category.Id == categoryId))
            {
                throw new ArgumentException(nameof(attributeId));
            }

            _context.CategoryAttributes.Add(new CategoryAttribute(categoryId, attributeId));

            await _context.SaveChangesAsync(default);
        }
    }
}