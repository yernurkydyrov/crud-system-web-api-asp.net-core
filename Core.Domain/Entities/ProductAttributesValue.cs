using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Entities

{
    public class ProductAttributesValue : BaseEntity
    {
        public ProductAttributesValue(int id, int productId, int attributeId, string value) : base(id)
        {
            ProductId = productId;
            AttributeId = attributeId;
            Value = value;
        }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey(nameof(Attribute))]
        public int AttributeId { get; set; }
        public Attribute Attribute { get; set; }
        public string Value { get; set; }

    }
}