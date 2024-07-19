using RESTfulAspNetWithChatGPT.Extensions;

var appName = "RESTful AspNet 8 With ChatGPT";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddChatGPT(/*builder.Configuration*/); // Add ChatGPT service
builder.AddSerilog(builder.Configuration, appName); // Add Serilog service
builder.Services.AddRouting(options => options.LowercaseUrls = true); // Add routing service to the container
builder.Services.AddControllers(); // Add MVC service
builder.Services.AddSwagger(builder.Configuration, appName); // Add Swagger service
builder.Services.AddEndpointsApiExplorer(); // Add API Explorer service

var app = builder.Build(); // Build the application

app.UseSwaggerDoc(appName); // Use Swagger documentation

app.UseHttpsRedirection(); // Use HTTPS redirection

app.MapControllers(); // Map controllers

/// <summary>
/// Default route for the application
/// </summary>
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Chat}/{action=Chat}/{id?}");

app.Run(); // Run the application
