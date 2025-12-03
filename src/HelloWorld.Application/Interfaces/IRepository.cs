using HelloWorld.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Application.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllActivesAsync();
        Task<T> GetByFilterASync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetListByFilterAsync(Expression<Func<T, bool>> filter);
        Task CreateAsync(T entity);
        Task CreateRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string id);
        void DeleteRange(IEnumerable<T> entities);
        Task SaveChangesAsync();
    }
}
