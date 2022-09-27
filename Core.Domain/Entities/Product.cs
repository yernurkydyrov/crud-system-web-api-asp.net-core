using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Entities

{
    public class Product : BaseEntity
    {
        public Product(int id, int categoryId) : base(id)
        {
            CategoryId = categoryId;
        }

        public Product(int categoryId)
        {
            CategoryId = categoryId;
        }


        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}