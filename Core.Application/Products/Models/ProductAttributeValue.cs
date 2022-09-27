using System;
using Core.Domain.Entities.Abstractions;

namespace Core.Application.Products.Models
{
    public class ProductAttributeValue
    {
        public int ProductId { get; set; }
        public int AttributeId { get; set; }
        public String Value { get; set; }

    }
}