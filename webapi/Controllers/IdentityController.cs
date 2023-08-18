using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class IdentityController : ControllerBase
{
    private const string TokenSecret = "this is my custom Secret key for authentication";
    private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(8);
    private const string AdminEmail = "admin@bookstore.com";

    [HttpPost(Name = "Token")]
    public IActionResult Token(
           [FromBody] TokenGenerationRequest request)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(TokenSecret);
        var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, request.Email),
                new(JwtRegisteredClaimNames.Email, request.Email),
                new("userid", request.UserId.ToString())
            };


        var claim = new Claim("admin", (request.Email == AdminEmail).ToString());
        claims.Add(claim);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(TokenLifetime),
            Issuer = "Test.org",
            Audience = "AudienceTest.com",
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)

        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwt = tokenHandler.WriteToken(token);
        var result = new TokenResp(jwt, request.Email == AdminEmail);
        return   Ok(result);
    }
}
