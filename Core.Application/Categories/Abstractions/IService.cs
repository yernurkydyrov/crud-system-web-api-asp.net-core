using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Application.Categories.Abstractions
{
    public interface IService<T>
    {
        public Task<IEnumerable<T>> View();
    }
}