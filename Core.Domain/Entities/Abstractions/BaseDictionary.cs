namespace Core.Domain.Entities.Abstractions
{
    public class BaseDictionary : BaseEntity
    {
        public string Name { get; set; }

        public BaseDictionary()
        {
            
        }
        
        public BaseDictionary(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}