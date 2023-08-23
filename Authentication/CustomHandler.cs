using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Authentication
{
    public class CustomHandler : RemoteAuthenticationHandler<CustomOptions>, IAuthenticationRequestHandler
    {
        public CustomHandler(IOptionsMonitor<CustomOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Console.WriteLine("HandleChallangeAsync called...");
            await Task.CompletedTask;
            Console.WriteLine("HandleChallangeAsync continued...");
            Response.Redirect("http://localhost:80");
            Console.WriteLine("HandleChallangeAsync ended???");
        }

        protected override async Task<HandleRequestResult> HandleRemoteAuthenticateAsync()
        {
            Console.WriteLine("HandleRemoteAuthenticateAsync called...");
            await Task.CompletedTask;
            return HandleRequestResult.NoResult();
        }
    }

}