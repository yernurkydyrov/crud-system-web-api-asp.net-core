using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Entities

{
    public class Category : BaseDictionary
    {
        public Category(int id, string name) : base(id, name)
        {
        }
    }
}