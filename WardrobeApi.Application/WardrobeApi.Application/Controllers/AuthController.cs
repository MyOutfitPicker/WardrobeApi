using Microsoft.AspNetCore.Mvc;

namespace WardrobeApi.Application.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            this._config = config;
        }

        [HttpGet("google-sign-in")]
        public IActionResult GoogleSignIn()
        {
            var clientId = this._config["Google:ClientId"];
            var redirectUri = this._config["Google:RedirectUri"];
            var scope = "email";

            var authorizationUrl = "https://accounts.google.com/o/oauth2/auth?" +
            $"client_id={Uri.EscapeDataString(clientId)}&" +
            $"redirect_uri={Uri.EscapeDataString(redirectUri)}&" +
            $"response_type=code&" +
            $"scope={Uri.EscapeDataString(scope)}&";

            return this.Redirect(authorizationUrl);
        }
    }
}