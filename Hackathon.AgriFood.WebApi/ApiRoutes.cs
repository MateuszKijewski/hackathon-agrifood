namespace Hackathon.AgriFood.WebApi
{
    public static class ApiRoutes
    {
        private const string Root = "api";

        public static class Customer
        {
            public const string Get = Root + "/customer/{customerId}";
            public const string Main = Root + "/customer";
        }

        public static class Localization
        {
            public const string Get = Root + "/localization/{localizationId}";
            public const string Main = Root + "/localization";
        }
    }
}