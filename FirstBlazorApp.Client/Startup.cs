using FirstBlazorApp.Shared;
using FirstBlazorApp.Shared.RabbitMq;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstBlazorApp.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTelerikBlazor();
            services.AddSingleton<ClientState>();
            services.AddSingleton<RandomValuesProvider>();

            var builder = new ConfigurationBuilder().AddJsonFile();

            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var rabbitMqConfigSection = Configuration.GetSection("RabbitMQ");
                var factory = new ConnectionFactory()
                {
                    HostName = rabbitMqConfigSection["HostName"]
                };

                if (!string.IsNullOrEmpty(rabbitMqConfigSection["VHostName"]))
                {
                    factory.VirtualHost = rabbitMqConfigSection["VHostName"];
                }

                if (!string.IsNullOrEmpty(rabbitMqConfigSection["Username"]))
                {
                    factory.UserName = rabbitMqConfigSection["Username"];
                }

                if (!string.IsNullOrEmpty(rabbitMqConfigSection["Password"]))
                {
                    factory.Password = rabbitMqConfigSection["Password"];
                }

                var retryCount = 5;
                if (!string.IsNullOrEmpty(rabbitMqConfigSection["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(rabbitMqConfigSection["EventBusRetryCount"]);
                }

                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            });
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
