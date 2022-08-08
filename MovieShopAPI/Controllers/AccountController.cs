using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.ApplicationCore.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieShopAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly IConfiguration configuration;
        public AccountController(IAccountService _accountService, IConfiguration _configuration)
        {
            accountService = _accountService;
            configuration = _configuration;
        }
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUpAsync(SignUpModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await accountService.SignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(new { Message = "User has been created successfully." });
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in result.Errors)
                {
                    sb.Append(item.Description);
                }
                return BadRequest(sb.ToString());
            }
        }
        public async Task<IActionResult> login(SignInModel model)
        {
            var result = await accountService.LoginAsync(model);
            if (!result.Succeeded)
                return Unauthorized(new { Message = "Invalid Username and Password." });
            //list of claims
            var authCalims = new List<Claim> {
                new Claim(ClaimTypes.Name, model.Email),
                new Claim(ClaimTypes.Country,"USA"),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()) //unique id 
            };

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT: ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authCalims,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)

                );
            var t = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { jwt = t });

        }
    }
}
