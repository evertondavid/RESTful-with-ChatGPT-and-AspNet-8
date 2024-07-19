// Purpose: Contains Serilog extensions for the WebApplicationBuilder.
using Serilog;

namespace RESTfulAspNetWithChatGPT.Extensions
{
    public static class SerilogExtensions
    {
        /// <summary>
        /// Adds Serilog to the WebApplicationBuilder using the specified configuration and app name
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configuration"></param>
        /// <param name="appName"></param>
        /// <returns></returns>
        public static WebApplicationBuilder AddSerilog(
            this WebApplicationBuilder builder,
            IConfiguration configuration,
            String appName
        )
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
            builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                .ReadFrom.Configuration(hostingContext.Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console());
            return builder;
        }
    }
}
