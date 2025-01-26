namespace SaxoOpenAPIClient
{
    public class SaxoClientOptions
    {
        public string BaseUrl { get; set; } = "https://gateway.saxobank.com/sim/openapi/";
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public string TokenUrl { get; set; } = "https://sim.logonvalidation.net/token";
        public string AuthorizationCode { get; set; }
    }
}
