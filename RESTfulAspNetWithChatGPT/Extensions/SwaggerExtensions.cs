// Purpose: Contains SwaggerExtensions class. This class contains extension methods for adding and using Swagger in the application.
using Microsoft.OpenApi.Models;

namespace RESTfulAspNetWithChatGPT.Extensions
{
    /// <summary>
    /// SwaggerExtensions class containing extension methods for adding and using Swagger in the application
    /// </summary>
    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services,
        IConfiguration configuration,
            string appName)
        {
            //services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = appName,
                        Version = "v1"
                    });
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                }
            );
        }

        /// <summary>
        /// Adds Swagger documentation to the application using the specified app name
        /// </summary>
        /// <param name="app"></param>
        /// <param name="appName"></param>
        public static void UseSwaggerDoc(
            this IApplicationBuilder app,
            string appName)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", appName);
                c.RoutePrefix = "swagger";
            });
        }
    }
}
