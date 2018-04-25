using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using CsvFileWebsite.Infrastructure.Modules;

namespace CsvFileWebsite.App_Start
{
    public class Startup
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(typeof(ServiceModule).Assembly);

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}