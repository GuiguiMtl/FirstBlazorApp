using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using BizDbAccess.App_Start;
using BizLogic.App_Start;

namespace ServiceLayer.App_Start
{
    public class ServiceLayerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Autowire the classes with interfaces
            builder.RegisterAssemblyTypes(GetType().Assembly).AsImplementedInterfaces();

            //-----------------------------
            //Now register the other layers
            builder.RegisterModule(new BizDbAccessModule());
            builder.RegisterModule(new BizLogicModule());
        }
    }
}
