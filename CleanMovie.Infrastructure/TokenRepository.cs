using CleanMovie.Application;
using CleanMovie.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanMovie.Infrastructure
{
    public class TokenRepository : ITokenRepository
    {
        Dictionary<string, string> UserRecords = new Dictionary<string, string>
        {
            {"admin", "admin"},
            {"password", "password"},
        };

        private readonly IConfiguration _configuration;
        public TokenRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Token Authenticate(User user)
        {
            if (!UserRecords.Any(u => u.Key == user.Name && u.Value == user.Name))
            {
                return null!;
            }
            // Generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescription);
            return new Token { Tokens = tokenHandler.WriteToken(token) };
        }
    }
}
