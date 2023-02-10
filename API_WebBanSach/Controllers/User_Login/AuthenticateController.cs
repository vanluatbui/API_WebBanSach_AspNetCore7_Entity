using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QLBanSach_API.DTO;
using QLBanSach_API.Entity;
using QLBanSach_API.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QLBanSach_API.Controller.User_Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        UserManager<User> userManager { get; set; } 
        IConfiguration configuration { get; set; }
        public AuthenticateController(UserManager<User> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        [HttpPost("token-login")]
        public async Task<ActionResult> GetToken(UserModel tokenModel)
        {
            try
            {
                var user = await
                userManager.FindByNameAsync(tokenModel.UserName);
                if (user == null)
                {
                    return Ok(new { result = false, message = "Can not find user" });
                }
                var result = await userManager.CheckPasswordAsync(user, tokenModel.Password);
                if (result)
                {
                    string securityKey = configuration["JWT:Secret"];
                    var symmetricSecurityKey = new
                    SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
                    var userRoles = await userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                        {
                        new Claim(ClaimTypes.Name, tokenModel.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString()),
                        };
                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var signingCredentials = new
                    SigningCredentials(symmetricSecurityKey,
                    SecurityAlgorithms.HmacSha256Signature);
                    var token = new JwtSecurityToken(
                    claims: authClaims,
                    issuer: configuration["JWT:ValidIssuer"],
                    audience: configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredentials
                    );
                    string strToken = new
                    JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(new { result = true, token = strToken });
                }
                return Ok(new { result = false, message = "Can not authenticate" });
            }
            catch (Exception ex)
            {
                return Ok(new { result = false, message = ex.Message });
                {
                }
            }
        }
    }
}
