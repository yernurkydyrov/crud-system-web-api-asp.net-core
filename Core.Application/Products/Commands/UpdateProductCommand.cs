using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Application.Interfaces;
using Core.Application.Products.Models;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Products.Commands
{
    public class UpdateProductCommand
    {
        public ProductDto ProductDto { get; set; }
        private readonly IAppDbContext _db;

        public UpdateProductCommand(IAppDbContext db)
        {
            _db = db;
        }

        public async Task UpdateProductAsync(CreateProductDto req)
        {
            var productDto = req;

            var product = await _db.Products.FindAsync(new object[] {productDto.CategoryId});

            if (product is null)
            {
                throw new InvalidOperationException("Product not found");
            }
            
            product.CategoryId = productDto.CategoryId;

            var deleteData = await _db.ProductAttributeValues
                .Where(p => p.ProductId == productDto.CategoryId).ToListAsync();
            _db.ProductAttributeValues.RemoveRange(deleteData);
            
            _db.ProductAttributeValues.AddRange(productDto.ProductAttributeValue
                .Select(p => new ProductAttributesValue(product.Id, p.AttributeId, p.Value)));

            await _db.SaveChangesAsync(CancellationToken.None);
        }

       
    }
}