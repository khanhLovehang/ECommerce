using Contracts.Manager;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Manager;
using Service.Contracts.Manager;
using Service.Manager;

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
             .AllowAnyHeader()
             .WithExposedHeaders("X-Pagination"));
          });

        //Configure an IIS integration which will eventually help us with the deployment to IIS
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
         services.Configure<IISOptions>(options =>
         {
         });

        //Add the logger service inside the .NET Core’s IOC container.
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        //Register repositorymanager class
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        //
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        //Register RepositoryContext
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<RepositoryContext>(opts =>
                     opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"))
                        .LogTo(Console.WriteLine));

        public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>
            builder.AddMvcOptions(config => config.OutputFormatters.Add(new CsvOutputFormatter()));

    }


}
