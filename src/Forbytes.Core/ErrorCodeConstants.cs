namespace Forbytes.Core
{
    public static class ErrorCodeConstants
    {
        public static class Platform
        {
            public const string ConnectionRefused = "connection-refused";
            public const string UnhandledException = "unhandled-exception";
        }

        public static class Request
        {
            public const string Invalid = "invalid";
            public const string NotFound = "not-found";
            public const string Validation = "validation";
            public const string PaymentRequired = "payment-required";
            public const string Conflict = "conflict";
            public const string Unhandled = "Unhandled";
        }
        
        public static class Response
        {
            public const string Unhandled = "unhandled";
            public const string NotFound = "not-found";
            public const string Unavailable = "unavailable";
            public const string Invalid = "invalid";
        }
    }
}