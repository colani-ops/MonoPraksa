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
using Planets.WebAPI.App_Start;

namespace Planets.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutofacConfig.StartAutofac();
        }
    }
}
