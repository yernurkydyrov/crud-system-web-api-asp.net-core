using System.Collections.Generic;
using Core.Domain.Entities;
using Core.Domain.Entities.Abstractions;

namespace Core.Application.Products.Models
{
    public class CreateProductDto
    {
        public int CategoryId { get; set; }
        public List<ProductAttributeValue> ProductAttributeValue { get; set; }

    }
}