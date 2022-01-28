using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ContactManager.Entities;
using ContactManager.Helpers;

namespace ContactManager.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateToken(User user, List<string> roles);
        public int? ValidateToken(string token);
    }

    public class JwtUtils : IJwtUtils
    {
        private readonly AppSettings _appSettings;

        public JwtUtils(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string GenerateToken(User user, List<string> roles)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256);
            
            var exp = DateTime.Parse("2022-09-21T14:53:04.970Z");
            var issuer = "GSI Challenge Authenticator";
            var audience = "www.gsichanllengeapi.com";
            
            var claims = new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim("sub", "gsicodingchallenge"),
                new Claim("GivenName", user.FirstName),
                new Claim("Surname", user.LastName),
                new Claim("Email", user.Email),
                new Claim(ClaimTypes.Country, "CU"),
            
            };
            var payload = new JwtPayload(issuer, audience, claims, null, exp, DateTime.UtcNow);
            payload.Add("Role", roles);
            
            var jwtToken = new JwtSecurityToken(new JwtHeader(signingCredentials), payload);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            return jwtTokenHandler.WriteToken(jwtToken);
        }

        public int? ValidateToken(string token)
        {
            if (token == null) 
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // return user id from JWT token if validation successful
                return userId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}