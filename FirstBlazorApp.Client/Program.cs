using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.Configuration;

namespace FirstBlazorApp.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();

        static void ConfigConfiguration(IConfigurationBuilder config)
        {
            config.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);

        }
    }
}
