using Businnes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IBasicService<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetId(long id);
        Task<T> Create(T book);
        Task<T> Update(T book);
        Task Delete(long id);
    }
}
