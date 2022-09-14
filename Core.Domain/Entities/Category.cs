using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Entities

{
    public class Category : BaseEntity
    {
        public Category(int id) : base(id)
        {
        }


        public string Name { get; set; }

    }
}