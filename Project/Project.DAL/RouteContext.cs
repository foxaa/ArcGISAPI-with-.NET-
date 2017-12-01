using Project.DAL.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public class RouteContext:DbContext,IRouteContext
    {

        public RouteContext() : base("RouteContext")
        {
            // base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Route> Routes { get; set; }//kreiramo tablicu

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // da nazivi tablica u bazi nebudu u mnozini
        }
    }
}
