using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Application.Interfaces;
using Core.Application.Products.Models;
using Core.Domain.Entities;
using MediatR;

namespace Core.Application.Products.Commands
{
    public class CreateProductCommand
    {
        public ProductDto ProductDto { get; set; }

        private readonly IAppDbContext _db;

        public CreateProductCommand(IAppDbContext db)
        {
            _db = db;
        }

        public async Task CreateProductAsync(CreateProductDto req)
        {
            var productDto = req;
            var product = new Product(productDto.CategoryId);
            _db.Products.Add(product);
            await _db.SaveChangesAsync(default);
            if (productDto.ProductAttributeValue.Any())
            {
                _db.ProductAttributeValues.AddRange(productDto.ProductAttributeValue.Select(i =>
                    new ProductAttributesValue(product.Id, i.AttributeId, i.Value)));
            }
            await _db.SaveChangesAsync(CancellationToken.None);
        }

        public async Task CreateProductAsync(ProductDto req)
        {
            var productDto = req;
            var product = new Product(productDto.CategoryId);
            _db.Products.Add(product);
            if (productDto.ProductAttributeValue.Any())
            {
                _db.ProductAttributeValues.AddRange(productDto.ProductAttributeValue.Select(i =>
                    new ProductAttributesValue(product.Id, i.Attributive.Id, i.Value)));
            }
            await _db.SaveChangesAsync(CancellationToken.None);
        }
        
    }
}