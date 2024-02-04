using Businnes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepository
{
    public interface IRepository <T> where T : BaseEntity
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetId(long id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(long id);
    }
}
