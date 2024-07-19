using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

namespace RESTfulAspNetWithChatGPT.Controllers
{
    /// <summary>
    /// Chat controller to interact with the GPT model using the OpenAI API
    /// </summary>
    [Route("bot/[controller]")]
    public class ChatController : Controller
    {
        private readonly OpenAIAPI _chatGpt;

        public ChatController(OpenAIAPI chatGpt)
        {
            _chatGpt = chatGpt;
        }
        /// <summary>
        /// Chat with the GPT model using the prompt provided in the query string
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Chat([FromQuery(Name = "prompt")] string prompt)
        {
            // Validate the prompt parameter
            try
            {
                if (string.IsNullOrEmpty(prompt))
                {
                    return BadRequest("Please provide a prompt in the query string");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            // First call to determine the model
            var initialChatRequest = new ChatRequest
            {
                Model = Model.ChatGPTTurbo, // Use a default model for this first call
                Messages = new List<ChatMessage>
                {
                    new ChatMessage(ChatMessageRole.User, "Determine the best Chat GPT model to use for the following prompt: " + prompt)
                }
            };

            var initialResponse = await _chatGpt.Chat.CreateChatCompletionAsync(initialChatRequest);
            var recommendedModel = initialResponse.Choices.FirstOrDefault()?.Message.TextContent.Trim();

            // Set the model based on the response from the first call
            var selectedModel = Model.ChatGPTTurbo; // Default
            if (recommendedModel != null && recommendedModel.Contains("Davinci", System.StringComparison.OrdinalIgnoreCase))
            {
                selectedModel = Model.Davinci;
            }
            else if (recommendedModel != null && recommendedModel.Contains("GPT-4", System.StringComparison.OrdinalIgnoreCase))
            {
                selectedModel = Model.GPT4;
            }

            // Second call with the appropriate model
            var chatRequest = new ChatRequest
            {
                Model = selectedModel,
                Messages = new List<ChatMessage>
                {
                    new ChatMessage(ChatMessageRole.User, prompt)
                }
            };

            // Third call to get the final response
            var finalResponse = await _chatGpt.Chat.CreateChatCompletionAsync(chatRequest);
            var resultText = finalResponse.Choices.FirstOrDefault()?.Message.TextContent;

            // Return the response to the client
            return Ok(resultText);
        }
    }
}
