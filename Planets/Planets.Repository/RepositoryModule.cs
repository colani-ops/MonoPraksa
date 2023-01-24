using Autofac;
using Planets.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets.Repository
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PlanetRepository>().As<PlanetRepository>();
            //builder.RegisterType<StarSystemRepository>().As<StarSystemRepository>();
        }

    }
}
