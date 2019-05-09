using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using DataLayer;
using GenericBizRunner.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServiceLayer.App_Start;
using Swashbuckle.AspNetCore.Swagger;

namespace TestBizRunnerEfCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1); services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddDbContext<MwoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CMS")));

            var containerBuilder = new ContainerBuilder();

            #region GenericBizRunner parts
            // Need to call AddAutoMapper to set up the mappings any GenericAction From/To Biz Dtos
            services.AddAutoMapper();
            //GenericBizRunner has two AutoFac modules that can register all the services needed
            //This one is the simplest, as it sets up the link to the application's DbContext
            containerBuilder.RegisterModule(new BizRunnerDiModule<MwoContext>());
            //Now I use the ServiceLayer AutoFac module that registers all the other DI items, such as my biz logic
            containerBuilder.RegisterModule(new ServiceLayerModule());
            #endregion

            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseMvc();

        }
    }
}
