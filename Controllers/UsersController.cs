using AutoMapper;
using CarMaintenance.Data;
using CarMaintenance.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarMaintenance.Models.Domain;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UsersController(IUserRepository userRepository, IMapper mapper)
    {
        this._userRepository = userRepository;
        this._mapper = mapper;
    }

    // GET: api/Users/5
    [HttpGet("{id}", Name = "GetUser")]
    public async Task<IActionResult> GetById(string id)
    {
        var userModel = await _userRepository.GetByIdAsync(id);

        if (userModel == null)
        {
            return NotFound();
        }

        var userDto = _mapper.Map<UserDto>(userModel);
        return Ok(userDto);
    }

    // POST: api/Users
    [HttpPost(Name = "CreateUser")]
    public async Task<IActionResult> Create([FromBody] AddUserDto addUserDto)
    {
        // Map DTO to Domain Model
        var userModel = _mapper.Map<User>(addUserDto);

        // Add to db
        userModel = await _userRepository.CreateAsync(userModel);

        // Map Domain Model to DTO
        var userDto = _mapper.Map<UserDto>(userModel);

        return CreatedAtAction(nameof(GetById), new { id = userDto.UserId }, userDto);
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}", Name = "DeleteUser")]
    public async Task<IActionResult> Delete(string id)
    {
        var userModel = await _userRepository.DeleteAsync(id);
        if (userModel == null)
        {
            return NotFound();
        }

        var userDto = _mapper.Map<UserDto>(userModel);
        return Ok(userDto);
    }
}