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

        public ProductAttributesValue(int productId, int attributeId, string value)
        {
            ProductId = productId;
            AttributeId = attributeId;
            Value = value;
        }

        public ProductAttributesValue()
        {
            
        }


        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey(nameof(Attributive))]
        public int AttributeId { get; set; }
        public Attributive Attributive { get; set; }
        public string Value { get; set; }

    }
}