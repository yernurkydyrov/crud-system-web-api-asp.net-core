using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Entities
{
    public class Attribute : BaseDictionary
    {
        public Attribute(int id, string name) : base(id, name)
        {
        }
    }
}