using Microsoft.AspNetCore.Authentication;

namespace Authentication
{
    public class CustomOptions : RemoteAuthenticationOptions
    {
        public string AuthorizationEndpoint { get; set; } = string.Empty;
    }
}