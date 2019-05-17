using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FirstBlazorApp.Shared;
using FirstBlazorApp.Shared.Services;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstBlazorApp.Client
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }
        public IContainer Container { get; private set; }


        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var containerBuilder = new ContainerBuilder();
            services.AddTelerikBlazor();
            services.AddSingleton<ClientState>();
            services.AddSingleton<RandomValuesProvider>();
            Configuration = BuildConfiguration();
            services.AddSingleton(Configuration);
            services.AddSingleton<ExportStockValuesToExcelService>();
           
            containerBuilder.Populate(services);

            Container = containerBuilder.Build();
            return new AutofacServiceProvider(Container);

        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }

        private IConfiguration BuildConfiguration()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var appSettingFile = assembly.GetName().Name + ".Configuration.appsettings.json";

            configurationBuilder.AddJsonFile(
                    new InMemoryFileProvider(assembly.GetManifestResourceStream(appSettingFile)), appSettingFile, false, false);

            return configurationBuilder.Build();
        }
    }
}
