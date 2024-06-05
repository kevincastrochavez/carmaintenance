using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarMaintenance.Data;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenRepository _tokenRepository;
    public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
    {
        this._userManager = userManager;
        this._tokenRepository = tokenRepository;
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
                var jwtToken = _tokenRepository.CreateJwtToken(userToLogin);
                var response = new LoginResponseDto
                {
                    JwtToken = jwtToken,
                    UserName = userToLogin.Email,
                    UserId = userToLogin.Id
                };

                return Ok(response);
            }
        }

        return BadRequest("Something went wrong with your login");
    }
}