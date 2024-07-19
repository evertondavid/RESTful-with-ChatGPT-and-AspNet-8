# ASP.NET 8 API with OpenAI GPT Integration

## Project Overview

This project is an ASP.NET 8 Web API designed to demonstrate the integration of OpenAI's GPT models, including GPT-4, GPT Davinci, and GPT Turbo. It provides endpoints that interact with these AI models, leveraging them for various applications such as text completion, summarization, and question-answering. The API uses a token stored in the environment variables for authentication with OpenAI, ensuring secure access.

### Features:

- **AI Integration**: Utilizes OpenAI's GPT-4, GPT Davinci, and GPT Turbo models.
- **Environment-Sensitive Configuration**: API keys and sensitive data are stored securely in environment variables.
- **Swagger Support**: Includes a fully documented Swagger UI for easy testing and interaction with the API endpoints.
- **Dynamic Model Selection**: The API dynamically selects the appropriate GPT model based on the query parameters.

## Technologies

- **ASP.NET 8**: The framework used for building the API.
- **OpenAI SDK**: SDK used for integrating GPT models.
- **Swagger**: API documentation and exploration tool.

## Getting Started

### Prerequisites

- .NET 8 SDK
- Visual Studio Code or another compatible IDE
- Access to OpenAI API (API key required)