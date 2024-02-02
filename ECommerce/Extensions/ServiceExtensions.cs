using Contracts;
using LoggerService;

namespace ECommerce.Extensions
{
    public static class ServiceExtensions
    {
        // Configuring CORS is mandatory to send requests from a different domain to our application
        public static void ConfigureCors(this IServiceCollection services) =>
          services.AddCors(options =>
          {
              options.AddPolicy("CorsPolicy", builder =>
             builder.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());
          });

        //Configure an IIS integration which will eventually help us with the deployment to IIS
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
         services.Configure<IISOptions>(options =>
         {
         });

        //Add the logger service inside the .NET Core’s IOC container.
        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();
    }


}
