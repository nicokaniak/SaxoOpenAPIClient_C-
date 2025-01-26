# Saxo Bank OpenAPI C# Client Library Documentation

## Overview
This documentation provides comprehensive coverage of the C# client library for the Saxo Bank OpenAPI. The library provides a strongly-typed, idiomatic C# interface to all Saxo Bank API services.

## Table of Contents
1. [Getting Started](#getting-started)
2. [Architecture](#architecture)
3. [Service Areas](#service-areas)
4. [Authentication](#authentication)
5. [Error Handling](#error-handling)
6. [Best Practices](#best-practices)
7. [Examples](#examples)

## Getting Started
### Installation
```xml
<PackageReference Include="SaxoOpenAPIClient" Version="1.0.0" />
```

### Basic Setup
```csharp
services.AddSaxoClient(options => {
    options.AppKey = "your-app-key";
    options.AppSecret = "your-app-secret";
    options.BaseUrl = "https://gateway.saxobank.com/sim/openapi/";
});
```

## Service Areas
The library covers all Saxo Bank OpenAPI service areas:

### Account & Portfolio
- Account History
- Asset Transfers
- Portfolio Management
- Performance Reporting

### Trading
- Orders (Single, Multi-leg, Conditional)
- Positions
- Trades
- Prices & Market Data
- Options Chain

### Market Data
- Real-time Prices
- Market Overview
- Charts
- Reference Data

### Client Services
- Client Management
- Client Reporting
- Regulatory Services
- Corporate Actions

### Integration Services
- Partner Integration
- ENS (Event Notification Service)
- Value Add Services

## Detailed Documentation
For detailed documentation of each service area, please refer to the following sections:
- [Trading Services](./Trading/README.md)
- [Portfolio Services](./Portfolio/README.md)
- [Market Data Services](./MarketData/README.md)
- [Client Services](./Client/README.md)
- [Integration Services](./Integration/README.md)
