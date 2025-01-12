using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AMAPP.Web.Middleware
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Cookies["jwt"];

            if (!string.IsNullOrEmpty(token))
            { 

                try
                {
                    var handler = new JwtSecurityTokenHandler();
                    var validationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = "AMAPP",
                        ValidAudience = "AMAPP",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("52d4c0f3bc65ec7eeb61ad63a99d782109696442893469b8fa001028a62a054a701c6bd32ab94517693c8e2312af68f04fbc7456769b31c0e915a53c328ec750504d4e5f26f5b8036308d95a50016f181dc382566ab2e932c5943acc93e9761f556d4a90284f82aefead0d25f0eed82182f2c209b4e02b5a4767eb863b3cbf3af1bc9c59daf240fb919e14e8215d8a804bda2bdbf8865feb11da952ae0a0ba8d667df6fc3a68b0e7ec8c94c6e929b1e89879e5397b8a861ea4e23989a33954323e031ae34402bf59dc7c3442510586502b04498bb47d6c9984f1f89a56e0b158bacdc62fca2fa6801a7b692d564b81eb288d08567f1d6ebe299d4fef6d9b0d49"))
                    };

                    handler.ValidateToken(token, validationParameters, out var validatedToken);

                    // Add claims to HttpContext
                    var jwtToken = validatedToken as JwtSecurityToken;
                    context.User = new ClaimsPrincipal(new ClaimsIdentity(jwtToken.Claims, "jwt"));
                }
                catch (Exception)
                {
                    // Token is invalid or expired; clear the cookie and redirect to login
                    context.Response.Cookies.Delete("jwt");
                    //context.Response.Redirect("/Account/Login");
                    context.Response.Redirect("/Home");
                    return;
                }
            }
            else
            {
                // No token; redirect to login
                //context.Response.Redirect("/Account/Login");
                context.Response.Redirect("/Home");
                return;
            }

            await _next(context);
        }
    }
}
