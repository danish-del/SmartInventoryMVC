using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartInventory.Insfrastructure.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartInventory.Insfrastructure.Service.Implementation
{
    public class JwtService
    {
        private readonly string _key;
        public JwtService(IConfiguration config)
        {
            _key = config["JWT:Key"] ?? throw new Exception("JWT key is not found!");
        }
        public string GenerateToken(AppUser user)
        {
            var Claims = new[]
            {
                new Claim(ClaimTypes.Name,user.UserName ?? "")
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: Claims,
                
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}     