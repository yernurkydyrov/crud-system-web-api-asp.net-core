using System.Collections.Generic;
using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Entities
{
    public class Attribute : BaseDictionary
    {
        public Attribute(int id, string name) : base(id, name)
        {
        }

        public Attribute(string name) : this(0, name)
        {
        }
        public ICollection<CategoryAttribute> AttributesCategory { get; set; }

    }
}