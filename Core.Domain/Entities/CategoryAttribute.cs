using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Entities

{
    public class CategoryAttribute : BaseEntity
    {
        public CategoryAttribute(int id, int categoryId, int attributeId) : base(id)
        {
            CategoryId = categoryId;
            AttributeId = attributeId;
        }

        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        [ForeignKey(nameof(Attribute))]
        public int? AttributeId { get; set; }
        public Attribute Attribute { get; set; }
    }
}