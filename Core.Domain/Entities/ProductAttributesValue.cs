using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Entities

{
    public class ProductAttributesValue : BaseEntity
    {
        public ProductAttributesValue(int id, int idProduct, int idAttributes, string value) : base(id)
        {
            IdProduct = idProduct;
            IdAttributes = idAttributes;
            Value = value;
        }

        [ForeignKey(nameof(Product))]
        public int IdProduct { get; set; }
        [ForeignKey(nameof(Attribute))]
        public int IdAttributes { get; set; }
        public string Value { get; set; }

    }
}