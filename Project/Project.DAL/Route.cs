using Project.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Project.DAL
{
    public class Route 
    {
       public Guid id { get; set; }
       public string name { get; set; }
       public double pointA_x { get; set; }
       public double pointA_y { get; set; }
       public double pointB_x { get; set; }
       public double pointB_y { get; set; }
       public DateTime? date { get; set; }

    }
}
