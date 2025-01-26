namespace SaxoOpenAPIClient.Constants
{
    /// <summary>
    /// API versions for different Saxo Bank OpenAPI services
    /// </summary>
    public static class ApiVersions
    {
        public static class Root
        {
            public const string V1 = "v1";
            public const string V2 = "v2";
        }

        public static class Trading
        {
            public const string V1 = "v1";
            public const string V2 = "v2";
        }

        public static class Portfolio
        {
            public const string V1 = "v1";
        }

        public static class Chart
        {
            public const string V1 = "v1";
        }

        public static class ReferenceData
        {
            public const string V1 = "v1";
        }

        public static class Market
        {
            public const string V1 = "v1";
        }

        // Add other service versions as they are discovered in the API
    }
}
