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

    // POST: api/Auth/Login
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var userToLogin = await _userManager.FindByEmailAsync(loginDto.Username);

        if (userToLogin != null)
        {
            var result = await _userManager.CheckPasswordAsync(userToLogin, loginDto.Password);

            if (result)
            {
                // TODO: Create JWT token
                return Ok("Logged in");
            }
        }

        return BadRequest("Something went wrong with your login");
    }
}