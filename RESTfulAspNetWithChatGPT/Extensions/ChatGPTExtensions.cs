// Purpose: Contains the extension method for adding the ChatGPT service to the WebApplicationBuilder.
using OpenAI_API;

namespace RESTfulAspNetWithChatGPT.Extensions
{
    /// <summary>
    /// Extension method to add the ChatGPT service to the WebApplicationBuilder
    /// </summary>
    public static class ChatGPTExtensions
    {
        public static WebApplicationBuilder AddChatGPT(
            this WebApplicationBuilder builder//,
                                              //IConfiguration configuration)
        )
        {
            try
            {
                //var key = configuration["ChatGPT:Key"];
                var key = Environment.GetEnvironmentVariable("OPENAI_API_KEY"); // Use this line instead of the above line if you are using environment variables to store the API key
                var chat = new OpenAIAPI(key);
                builder.Services.AddSingleton(chat);
                return builder;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding ChatGPT service: " + ex.Message);
            }
        }
    }
}
