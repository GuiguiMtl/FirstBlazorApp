using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace BizDbAccess.App_Start
{
    public class BizDbAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Autowire the classes with interfaces
            builder.RegisterAssemblyTypes(GetType().Assembly).AsImplementedInterfaces();
        }
    }
}
