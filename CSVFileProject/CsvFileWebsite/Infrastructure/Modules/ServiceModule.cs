using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using CsvFileProject.Common.Services.Interfaces;
using CsvFileWebsite.Infrastructure.Services;

namespace CsvFileWebsite.Infrastructure.Modules
{
    public class ServiceModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ICustomerService).Assembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(ICsvFileReaderService).Assembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces();
        }
    }
}