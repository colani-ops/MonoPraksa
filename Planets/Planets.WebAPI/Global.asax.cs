using Autofac;
using Autofac.Integration.WebApi;
using Planets.Service;
using Planets.Service.Common;
using Planets.Repository;
using Planets.Repository.Common;
using Planets.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Reflection;

namespace Planets.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterType <PlanetService>().As<IPlanetService>();
            builder.RegisterType <PlanetRepository>().As<IPlanetRepository>();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterType <StarSystemService>().As<IStarSystemService>();
            //builder.RegisterType <StarSystemRepository>().As<IStarSystemRepository>();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}
