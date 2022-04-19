using API.Entities;
using API.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        // Symmetric Encription is used to encrypt and decrypt electronic info
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(AppUser user)
        {
            // throw new System.NotImplementedException();
            
            // Adding Our Claims
            var claims = new List<Claim>
           {
               new Claim(JwtRegisteredClaimNames.NameId,user.UserName)
           };
           
            // Creating Some Credintial
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            
            // Describing how our token look
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };
            // Creating Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();
            // Creating Token   
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // return the token
            return tokenHandler.WriteToken(token);
        }
    }
}
