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
        Task<T> GetByFilterASync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetListByFilterAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByFilterWithIncludeAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        Task CreateAsync(T entity);
        Task CreateRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string id);
        void DeleteRange(IEnumerable<T> entities);
        Task HardDeleteAsync(string id);
        void HardDeleteRange(IEnumerable<T> entities);
        Task SaveChangesAsync();
    }
}
