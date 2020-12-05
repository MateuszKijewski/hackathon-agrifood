namespace Hackathon.AgriFood.WebApi
{
    public static class ApiRoutes
    {
        private const string Root = "api";

        public static class Customer
        {
            public const string Get = Root + "/customer/{eventId}";
            public const string Main = Root + "/customer";
        }
    }
}