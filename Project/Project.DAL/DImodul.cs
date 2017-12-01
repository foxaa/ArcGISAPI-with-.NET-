using Ninject.Modules;
using Project.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public class DImodul : NinjectModule
    {
        public override void Load()
        {
            Bind<IRouteContext>().To<RouteContext>();
        }
    }
}
