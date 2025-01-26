namespace SaxoOpenAPIClient.Core
{
    public class SaxoClientOptions
    {
        public string BaseUrl { get; set; } = "https://gateway.saxobank.com/sim/openapi/";
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public string AuthorizationEndpoint { get; set; } = "https://sim.logon.saxo/openapi/authorize";
        public string TokenEndpoint { get; set; } = "https://sim.logon.saxo/openapi/token";
        public string TokenValidationEndpoint { get; set; } = "https://sim.logon.saxo/openapi/token/validate";
        public string TokenRevocationEndpoint { get; set; } = "https://sim.logon.saxo/openapi/token/revoke";
        public string StreamingUrl { get; set; } = "wss://streaming.saxobank.com/sim/openapi/streamingws/connect";
        public string AuthorizationCode { get; set; }
    }
}
