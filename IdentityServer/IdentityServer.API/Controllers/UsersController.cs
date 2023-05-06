using IdentityServer.API.Dtos;
using IdentityServer.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServer.API.Controllers;

[Authorize(LocalApi.PolicyName)]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UsersController(UserManager<ApplicationUser> userManager)
    {
        this._userManager = userManager;
    }
    [HttpPost]
    public async Task<IActionResult> SignUp(SignupDto signupDto)
    {
        var user = new ApplicationUser
        {
            UserName = signupDto.UserName,
            Email = signupDto.Email,
            City = signupDto.City
        };

        var result = await _userManager.CreateAsync(user, signupDto.Password);

        if (!result.Succeeded)
        {
            return BadRequest("There is a problem");
        }

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetUser()
    {
        var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

        if (userIdClaim == null) return BadRequest();

        var user = await _userManager.FindByIdAsync(userIdClaim.Value);

        if (user == null) return BadRequest();

        return Ok(new { Id = user.Id, UserName = user.UserName, Email = user.Email, City = user.City });
    }
}
