using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Models.DTOs;
using backend.Models.Enums;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    
    public RegisterController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    // register new user
    [HttpPost("azubi")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterAzubi([FromBody] RegisterDTOAzubi registerDto)
    {
        // check if user exists already
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == registerDto.Email);
        if (existingUser != null)
        {
            return BadRequest();
        }
        
        // get occupation from abbreviation
        
        
        // add user and profile
        var user = new User()
        {
            LocalUsername = registerDto.Username,
            Email = registerDto.Email,
        };
        var profile = new AzubiProfile()
        {
            assocUser =  user,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            TrainingStartYear = registerDto.TrainingStartYear
        };
        
        await _context.Users.AddAsync(user);
        await _context.AzubiProfiles.AddAsync(profile);
        return Ok(profile);
    }
    
    [HttpPost("abb")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterABB([FromBody] RegisterDTOABB registerDto)
    {
        // check if user exists already
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == registerDto.Email);
        if (existingUser != null)
        {
            return BadRequest();
        }
        
        // add user
        var user = new User()
        {
            LocalUsername = registerDto.Username,
            Email = registerDto.Email,
        };
        var profile = new ABBProfile()
        {
            assocUser =  user,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            DepartmentAbbr = registerDto.DepartmentAbbr
        };
        await _context.Users.AddAsync(user);
        await _context.ABBProfiles.AddAsync(profile);
        await _context.SaveChangesAsync();
        return Ok(profile);
    }
}