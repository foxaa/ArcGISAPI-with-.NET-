using Project.DAL.Common;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class GenericService : IGenericService
    {
        private IRouteContext _context;
        public GenericService(IRouteContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAllAsync<T>(IEnumerable<T> entity) where T : class
        {
            foreach(var ent in entity)
            {
                _context.Set<T>().Remove(ent);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            T entity =await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync<T>(Guid id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<int> UpdateAsync<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
