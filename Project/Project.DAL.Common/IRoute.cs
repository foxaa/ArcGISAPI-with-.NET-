using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Common
{
    public interface IRoute
    {
        Guid id { get; set; }
        string name { get; set; }
        double pointA_x { get; set; }
        double pointA_y { get; set; }
        double pointB_x { get; set; }
        double pointB_y { get; set; }
    }
}
