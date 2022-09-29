using System.Collections.Generic;
using Core.Domain.Entities.Abstractions;

namespace Core.Application.Products.Models
{
    public class UpdateProductDto : BaseEntity
    {
        public int CategoryId { get; set; }
        public List<UpdateProductValueDtos> ProductAttributeValue { get; set; }

    }
}