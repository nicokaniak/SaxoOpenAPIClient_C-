# Authentication Documentation

## Overview
The Saxo Bank OpenAPI supports three OAuth2 authentication flows:
1. Authorization Code Flow
2. PKCE (Proof Key for Code Exchange) Flow
3. Certificate-Based Authentication (CBA)

## Authorization Code Flow
This is the standard OAuth2 flow for web applications where both authorization and token endpoints are used.

### Steps:
1. Redirect user to authorization endpoint:
```csharp
var authService = serviceProvider.GetService<IAuthenticationService>();
var authUrl = await authService.GetAuthorizationUrlAsync(new AuthorizationRequest {
    ClientId = "your-client-id",
    RedirectUri = "your-redirect-uri",
    State = "random-state-string"
});
```

2. Handle the callback and exchange code for tokens:
```csharp
var tokenResponse = await authService.GetTokenFromCodeAsync(new TokenRequest {
    Code = "auth-code-from-callback",
    ClientId = "your-client-id",
    ClientSecret = "your-client-secret",
    RedirectUri = "your-redirect-uri"
});
```

## PKCE Flow
Enhanced version of the Authorization Code flow that prevents CSRF and authorization code injection attacks.

### Steps:
1. Generate PKCE values:
```csharp
var pkce = await authService.GeneratePkceValuesAsync();
```

2. Get authorization URL with PKCE challenge:
```csharp
var authUrl = await authService.GetAuthorizationUrlAsync(new AuthorizationRequest {
    ClientId = "your-client-id",
    RedirectUri = "your-redirect-uri",
    State = "random-state-string",
    CodeChallenge = pkce.CodeChallenge,
    CodeChallengeMethod = "S256"
});
```

3. Exchange code for tokens using PKCE verifier:
```csharp
var tokenResponse = await authService.GetTokenFromCodeAsync(new TokenRequest {
    Code = "auth-code-from-callback",
    ClientId = "your-client-id",
    RedirectUri = "your-redirect-uri",
    CodeVerifier = pkce.CodeVerifier
});
```

## Certificate-Based Authentication
Used for server-to-server integrations where user interaction is not required.

### Steps:
1. Configure certificate:
```csharp
var tokenResponse = await authService.GetTokenWithCertificateAsync(new CertificateAuthRequest {
    ClientId = "your-client-id",
    ClientSecret = "your-client-secret",
    CertificateFile = "path/to/certificate.pfx",
    CertificatePassword = "certificate-password"
});
```

## Token Management
All authentication flows return a `TokenResponse` that includes:
- Access Token
- Refresh Token
- Token Expiration
- Base URI for API calls

### Refreshing Tokens
```csharp
var newTokenResponse = await authService.RefreshTokenAsync(new RefreshTokenRequest {
    RefreshToken = "your-refresh-token",
    ClientId = "your-client-id",
    ClientSecret = "your-client-secret"
});
```

## Best Practices
1. Always store tokens securely
2. Refresh tokens before they expire
3. Use PKCE flow for public clients
4. Use certificate-based auth for server applications
5. Implement proper error handling for auth failures

## Error Handling
The authentication service throws specific exceptions:
- `SaxoAuthenticationException`: General authentication errors
- `SaxoTokenExpiredException`: Token has expired
- `SaxoInvalidGrantException`: Invalid grant type or credentials
- `SaxoAuthorizationPendingException`: Authorization is still pending

## Configuration
Configure the authentication service in your DI container:
```csharp
services.AddSaxoAuthentication(options => {
    options.AuthorizationEndpoint = "https://sim.logon.saxo/openapi/authorize";
    options.TokenEndpoint = "https://sim.logon.saxo/openapi/token";
    options.ApiBaseUrl = "https://gateway.saxobank.com/sim/openapi";
});
```
