using Microsoft.IdentityModel.Tokens;
using MiniApi_AuthUser.Application.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiniApi_AuthUser.Application.Service.Implementation
{
    public class TokenService : ITokenService
    {
        private SymmetricSecurityKey _key;
        public TokenService()
        {
            string secrtKey = "kwOoQl4re*EniutHkn4*B9td4ulize@tatf6v1ljkldd1715ba111bdb55282621221";
            byte[] data = Encoding.UTF8.GetBytes(secrtKey);

            _key = new SymmetricSecurityKey(data);

        }
        public string GetToken()
        {
            var claim = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,"1")
            };
            var SigningCredential = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject= new ClaimsIdentity(claim),
                Expires= DateTime.Now.AddDays(1),
                SigningCredentials= SigningCredential
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token=tokenHandler.CreateToken(tokenDescription);
            
            return  tokenHandler.WriteToken(token);
        }
    }
}

