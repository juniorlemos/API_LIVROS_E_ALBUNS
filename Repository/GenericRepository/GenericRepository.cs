using Businnes;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepository
{
    public class GenericRepository <T> : IRepository<T> where T : BaseEntity
    {
        private ApplicationDbContext _context;
        private DbSet<T> dataset;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> Get()
        {
            return await dataset.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetId(long id)
        {
            return await dataset.FindAsync(id);
        }
        public async Task<T> Create(T entity)
        {
            try
            {
                dataset.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<T> Update(T entity)
        {
            var result = dataset.Find(entity.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(entity);
                    await _context.SaveChangesAsync();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task Delete(long id)
        {
            var result = dataset.Find(id);
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}

