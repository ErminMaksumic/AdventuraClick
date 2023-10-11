using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace AdventuraClick.Authorization
{
    public class BasicAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        private readonly IConfiguration _configuration;

        public BasicAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IConfiguration configuration)
            : base(options, logger, encoder, clock)
        {
            this._configuration = configuration;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing auth header!");
            }

            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var token = authHeader.Parameter;

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["keyjwt"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration["keyjwt"],
                    ValidAudience = _configuration["keyjwt"],
                    IssuerSigningKey = key
                }, out SecurityToken validatedToken);

                var claimsIdentity = new ClaimsIdentity(principal.Claims, Scheme.Name);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                var authenticationTicket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);

                return AuthenticateResult.Success(authenticationTicket);
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid token!");
            }
        }
    }
}