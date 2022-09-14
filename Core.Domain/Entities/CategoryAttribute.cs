using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Entities

{
    public class CategoryAttribute : BaseEntity
    {
        public CategoryAttribute(int idCategory, int idAttributes) : this(0, idCategory, idAttributes)
        {
        }

        public CategoryAttribute(int id, int idCategory, int idAttributes) : base(id)
        {
            IdCategory = idCategory;
            IdAttributes = idAttributes;
        }

        [ForeignKey(nameof(Category))]
        public int? IdCategory { get; set; }
        [ForeignKey(nameof(Attribute))]
        public int? IdAttributes { get; set; }

    }
}