using System.Collections.Generic;
using Core.Application.Abstractions.Models;
using Core.Application.Attributes.Models;

namespace Core.Application.Categories.Models
{
    public class CategoryDto : BaseDictionaryDto
    {
        public ICollection<AttributeDto> Attributes { get; set; }
    }
}