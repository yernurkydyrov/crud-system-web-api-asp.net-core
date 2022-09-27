using System;
using Core.Application.Attributes.Models;

namespace Core.Application.Products.Models
{
    public class ProductAttributeValueDto
    {
        public AttributeDto AttributeDto { get; set; }
        public String Value { get; set; }

        public ProductAttributeValueDto()
        {
            
        }

        public ProductAttributeValueDto(AttributeDto attributeDto, string value)
        {
            AttributeDto = attributeDto;
            Value = value;
        }
        
    }
}