using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarMaintenance.Data;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    public AuthController(UserManager<IdentityUser> userManager)
    {
        this._userManager = userManager;
    }

    // POST: api/Auth/Register
    [HttpPost(Name = "Register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var userToRegister = new IdentityUser
        {
            UserName = registerDto.Username,
            Email = registerDto.Username
        };

        var result = await _userManager.CreateAsync(userToRegister, registerDto.Password);

        if (result.Succeeded)
        {
            return Ok("User created, please log in");
        }

        return BadRequest("Something went wrong with your registration");
    }
}