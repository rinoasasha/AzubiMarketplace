using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using backend.Models;
using backend.Models.DTOs;
using backend.Models.Enums;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<UserRole> _roleManager;
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    
    public UserController(DataContext context, IMapper mapper, UserManager<User> userManager, RoleManager<UserRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
        _mapper = mapper;
    }
    
    // get all users
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserDTO>))]
    public async Task<IActionResult> Get()
    {
        var users = await _userManager.Users.ToListAsync();
        return Ok(_mapper.Map<List<UserDTO>>(users));
    }
    
    // get user by username
    [HttpGet("{username}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetFromName([FromRoute]string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.LocalUsername == username);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<UserDTO>(user));
    }
    
    // get user by userId
    
    // get role azubi
    [HttpPatch("/azubi")]
    public async Task<IActionResult> MakeAzubi()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null)
        {
            return NotFound();
        }
        var success = await _userManager.AddToRoleAsync(user, "Azubi");
        return Ok(success);
    }
    
    // get role abb
    [HttpPatch("/abb")]
    public async Task<IActionResult> MakeABB()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null)
        {
            return NotFound();
        }
        var success = await _userManager.AddToRoleAsync(user, "ABB");
        return Ok(success);
    }
}