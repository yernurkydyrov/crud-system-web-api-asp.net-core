using System.Collections.Generic;
using Core.Application.Abstractions.Models;
using Core.Domain.Entities;
using Core.Domain.Entities.Abstractions;

namespace Core.Application.Products.Models
{
    public class ProductDto : BaseEntity
    {
        public int CategoryId { get; set; }
        public List<ProductAttributesValue> ProductAttributeValue { get; set; }
        
    }
}