using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Entities
{
    public class Attribute : BaseEntity
    {
        public string Name { get; set; }

        public Attribute(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}