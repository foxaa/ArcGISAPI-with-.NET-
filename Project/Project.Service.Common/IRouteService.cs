using Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IRouteService
    {
        Task<IEnumerable<Route>> GetAllAsync();
        Task<int> AddAsync(Route entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAllAsync(IEnumerable<Route> entity);
        Task<int> UpdateAsync(Route entity);
        Task<Route> GetAsync(Guid id);
    }
}
