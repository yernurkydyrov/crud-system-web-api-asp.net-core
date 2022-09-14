using Microsoft.EntityFrameworkCore;

namespace Insfrastructure.Persistance.Initalizes
{
    public class AppDbInitializer
    {
        public static void Initialize(DbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}