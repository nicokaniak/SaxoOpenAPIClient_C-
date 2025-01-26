# Saxo Bank OpenAPI Client Library

A .NET Standard library for interacting with the Saxo Bank OpenAPI.

## Features

- Modern C# implementation using .NET Standard 2.1
- Built-in support for authentication flows
- Dependency injection ready
- Proper error handling and JSON serialization
- Type-safe request/response DTOs

## Installation

Add the project reference to your solution or install via NuGet (once published).

## Usage

1. Register the client in your DI container:

```csharp
services.AddSaxoClient(options =>
{
    options.AppKey = "your-app-key";
    options.AppSecret = "your-app-secret";
    options.AuthorizationCode = "your-auth-code"; // From OAuth flow
});
```

2. Inject and use the client:

```csharp
public class YourService
{
    private readonly ISaxoClient _saxoClient;

    public YourService(ISaxoClient saxoClient)
    {
        _saxoClient = saxoClient;
    }

    public async Task DoSomethingAsync()
    {
        var result = await _saxoClient.GetAsync<YourResponseType>("endpoint/path");
        // Handle result
    }
}
```

## Authentication

The library handles authentication automatically using the provided credentials. Make sure to:

1. Register your application at Saxo Bank's Developer Portal
2. Obtain your App Key and App Secret
3. Implement the OAuth 2.0 flow to get the authorization code
4. Configure the client with these credentials

## Documentation

For more information about the Saxo Bank OpenAPI:

- [Official API Reference](https://www.developer.saxo/openapi/referencedocs)
- [OpenAPI Learning Portal](https://www.developer.saxo/openapi/learn)

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.
