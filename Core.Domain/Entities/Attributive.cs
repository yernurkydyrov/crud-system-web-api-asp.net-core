using System.Collections.Generic;
using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Entities
{
    public class Attributive : BaseDictionary
    {
        public Attributive(int id, string name) : base(id, name)
        {
        }

        public Attributive(string name) : this(0, name)
        {
        }
        public ICollection<CategoryAttribute> AttributesCategory { get; set; }

    }
}