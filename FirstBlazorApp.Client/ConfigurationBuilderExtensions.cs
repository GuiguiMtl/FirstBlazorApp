using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBlazorApp.Client
{
    public static class ConfigurationBuilderExtensions
    {
        public static void ConfigConfiguration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IConfiguration>((s) =>
            {
                ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                var appSettingFile = assembly.GetName().Name + "appsettings.json";
                configurationBuilder.AddJsonFile(appSettingFile, optional: false, reloadOnChange: true);

                return configurationBuilder.Build();
            });


        }
    }
}
