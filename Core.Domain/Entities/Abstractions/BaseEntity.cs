namespace Core.Domain.Entities.Abstractions
{
    public class BaseEntity
    {
        private BaseEntity()
        {
            
        }
        
        public BaseEntity(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}