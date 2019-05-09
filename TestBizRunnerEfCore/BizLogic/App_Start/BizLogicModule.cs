using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace BizLogic.App_Start
{
    public class BizLogicModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            //Autowire the classes with interfaces
            builder.RegisterAssemblyTypes(GetType().Assembly).AsImplementedInterfaces();
        }
    }
}
