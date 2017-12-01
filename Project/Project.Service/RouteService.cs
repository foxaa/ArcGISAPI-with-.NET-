using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL;

namespace Project.Service
{
    public class RouteService : IRouteService
    {
        private IGenericService _context;
        public RouteService(IGenericService context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Route entity)
        {
            return await _context.AddAsync(entity);
        }

        public async Task<int> DeleteAllAsync(IEnumerable<Route> entity)
        {
            return await _context.DeleteAllAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await _context.DeleteAsync<Route>(id);
        }

        public async Task<IEnumerable<Route>> GetAllAsync()
        {
            return await _context.GetAllAsync<Route>();
        }

        public async Task<Route> GetAsync(Guid id)
        {
            return await _context.GetAsync<Route>(id);
        }

        public async Task<int> UpdateAsync(Route entity)
        {
            return await _context.UpdateAsync(entity);
        }
    }
}
