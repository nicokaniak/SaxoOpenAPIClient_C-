# Trading Services Documentation

## Overview
The Trading services provide comprehensive access to Saxo Bank's trading functionality, including order management, position tracking, and trade execution.

## Services

### Orders Service
#### Features
- Single Order Management
- Multi-leg Option Strategies
- Conditional Orders
- OCO (One-Cancels-Other) Orders
- Order Templates
- Pre-trade Validation

#### Usage Examples
```csharp
// Place a simple market order
var orderService = serviceFactory.GetService<IOrdersService>();
var response = await orderService.PlaceOrderAsync(new OrderRequest {
    AccountKey = "your-account",
    AssetType = "FxSpot",
    Amount = 10000,
    BuySell = "Buy",
    OrderType = "Market",
    Uic = 21 // EURUSD
});

// Place a multi-leg option strategy
var strategyOrder = await orderService.PlaceMultiLegOrderAsync(new MultiLegOrderRequest {
    AccountKey = "your-account",
    AssetType = "StockOption",
    StrategyType = "Straddle",
    Legs = new[] {
        new OrderLeg { /* ... */ },
        new OrderLeg { /* ... */ }
    }
});
```

### Positions Service
#### Features
- Position Monitoring
- Position Modification
- Exercise Options
- Position Rollover
- Margin Impact Analysis

#### Usage Examples
```csharp
var positionService = serviceFactory.GetService<IPositionsService>();
var positions = await positionService.GetPositionsAsync("your-account");
```

### Price Service
#### Features
- Real-time Price Streaming
- Price History
- Market Depth
- Info Prices
- Price Alerts

#### Usage Examples
```csharp
var priceService = serviceFactory.GetService<IPricesService>();
var subscription = await priceService.SubscribeToPricesAsync(
    new[] { 21 }, // EURUSD
    new[] { "FxSpot" }
);
```

## Error Handling
All services implement comprehensive error handling:
```csharp
try {
    var order = await orderService.PlaceOrderAsync(request);
} catch (SaxoOrderValidationException ex) {
    // Handle validation errors
} catch (SaxoInsufficientMarginException ex) {
    // Handle margin issues
} catch (SaxoApiException ex) {
    // Handle other API errors
}
```

## Best Practices
1. Always use pre-trade validation for orders
2. Implement proper error handling
3. Use streaming subscriptions for real-time data
4. Properly dispose of subscriptions
5. Monitor rate limits
