using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Abstracts;
using HelloWorld.Domain.Enums;
using HelloWorld.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly HelloWorldDbContext _context;

        public Repository(HelloWorldDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task CreateRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            entity!.Status = EntityStatus.Deleted;
            _context.Set<T>().Update(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.Status = EntityStatus.Deleted;
            }
            _context.Set<T>().UpdateRange(entities);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().Where(e => e.Status != EntityStatus.Deleted).ToListAsync();
        }

        public async Task<T> GetByFilterASync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(x => x.Status != EntityStatus.Deleted).FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetByFilterWithIncludeAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>().Where(x => x.Status != EntityStatus.Deleted);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().Where(x => x.Status != EntityStatus.Deleted).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetListByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(x => x.Status != EntityStatus.Deleted).Where(filter).ToListAsync();
        }

        public async Task HardDeleteAsync(string id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
        }

        public void HardDeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            entity.Status = EntityStatus.Updated;
            _context.Set<T>().Update(entity);
        }
    }
}