using AutoMapper;
using CarMaintenance.Data;
using CarMaintenance.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarMaintenance.Models.Domain;

[Route("api/[controller]")]
[ApiController]
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
}