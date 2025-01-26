# Saxo Bank OpenAPI C# Client Library

[![NuGet](https://img.shields.io/nuget/v/SaxoOpenAPIClient.svg)](https://www.nuget.org/packages/SaxoOpenAPIClient)
[![License](https://img.shields.io/github/license/yourusername/SaxoOpenAPIClient)](LICENSE)

A comprehensive C# client library for the Saxo Bank OpenAPI, providing a strongly-typed, idiomatic interface to all Saxo Bank API services.

## Features

-  **Complete Authentication Support**
  - OAuth2 Authorization Code Flow
  - PKCE Flow for public clients
  - Certificate-Based Authentication (CBA)
  - Automatic token management

-  **Trading & Orders**
  - Single orders
  - Multi-leg option strategies
  - OCO (One-Cancels-Other) orders
  - Algorithmic orders
  - Conditional orders
  - Block orders

-  **Portfolio Management**
  - Position tracking
  - Order management
  - Account balances
  - Performance metrics
  - Report generation

-  **Market Data**
  - Real-time price streaming
  - Market depth
  - Historical data
  - Options chain
  - Trade messages

-  **Real-time Updates**
  - WebSocket streaming
  - Event notifications
  - Connection management
  - Automatic reconnection

## Installation

```bash
dotnet add package SaxoOpenAPIClient
```

## Quick Start

1. **Configure Services**
```csharp
services.AddSaxoClient(options =>
{
    options.AppKey = "your-app-key";
    options.AppSecret = "your-app-secret";
    options.BaseUrl = "https://gateway.saxobank.com/sim/openapi/";
});
```

2. **Authentication**
```csharp
// OAuth2 Authorization Code Flow
var authService = serviceProvider.GetService<IAuthenticationService>();
var authUrl = await authService.GetAuthorizationUrlAsync(new AuthorizationRequest
{
    ClientId = "your-client-id",
    RedirectUri = "your-redirect-uri",
    State = "random-state"
});

// Handle callback and get token
var token = await authService.GetTokenFromCodeAsync(new TokenRequest
{
    Code = "auth-code-from-callback",
    ClientId = "your-client-id",
    RedirectUri = "your-redirect-uri"
});
```

3. **Place an Order**
```csharp
var orderService = serviceProvider.GetService<IOrdersService>();
var response = await orderService.PlaceOrderAsync(new OrderRequest
{
    AccountKey = "your-account",
    AssetType = "FxSpot",
    BuySell = "Buy",
    Amount = 10000,
    Uic = 21, // EURUSD
    OrderType = "Market"
});
```

4. **Stream Real-time Prices**
```csharp
var marketDataService = serviceProvider.GetService<IMarketDataService>();
var subscription = await marketDataService.SubscribeToPricesAsync(
    assetType: "FxSpot",
    uic: 21,
    refreshRate: 1000
);

// Handle price updates
subscription.PriceUpdated += (sender, price) =>
{
    Console.WriteLine($"New price: Bid={price.Quote.Bid}, Ask={price.Quote.Ask}");
};
```

## Documentation

For detailed documentation, see the [Documentation](Documentation) directory:

- [Authentication](Documentation/Authentication/README.md)
- [Trading Services](Documentation/Trading/README.md)
- [Portfolio Services](Documentation/Portfolio/README.md)
- [Market Data Services](Documentation/MarketData/README.md)

## Examples

The [Examples](Examples) directory contains complete working examples:

- Basic order placement
- Real-time price streaming
- Portfolio management
- OAuth2 authentication flows

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## Testing

```bash
dotnet test
```

The test suite includes:
- Unit tests
- Integration tests (requires Saxo Bank simulation environment)
- Performance tests

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- [Saxo Bank OpenAPI Documentation](https://www.developer.saxo/openapi/learn)
- [OpenAPI Sample Repositories](https://github.com/SaxoBank)

## Support

For support, please:
1. Check the [Documentation](Documentation)
2. Search [Issues](../../issues)
3. Create a new issue if needed

## Security

This library follows security best practices:
- No sensitive data logging
- Secure token handling
- PKCE support for public clients
- Certificate validation

## Related Projects

- [Saxo Bank OpenAPI Samples (JavaScript)](https://github.com/SaxoBank/openapi-samples-js)
- [Saxo Bank OpenAPI Samples (C#)](https://github.com/SaxoBank/openapi-samples-csharp)

## Need Help?

Feel free to [open an issue](../../issues/new) or contact the maintainers.
