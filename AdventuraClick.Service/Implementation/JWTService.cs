using AdventuraClick.Model;
using AdventuraClick.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtService : IJWTService
{
    private readonly IConfiguration _configuration;
    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Username),
            new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
            new Claim(ClaimTypes.Role, user.Role.Name)
        };

        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["keyjwt"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["keyjwt"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}