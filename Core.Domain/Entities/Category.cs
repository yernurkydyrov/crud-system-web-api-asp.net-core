using System.Collections.Generic;
using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Entities

{
    public class Category : BaseDictionary
    {
        public Category()
        {
            
        }
        
        public Category(int id, string name) : base(0, name)
        {
        }

        public ICollection<CategoryAttribute> CategoryAttributes { get; set; }
    }
}