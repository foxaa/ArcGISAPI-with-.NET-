using Ninject.Modules;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class DImodul : NinjectModule
    {
        public override void Load()
        {
            Bind<IGenericService>().To<GenericService>();
            Bind<IRouteService>().To<RouteService>();
        }
    }
}
