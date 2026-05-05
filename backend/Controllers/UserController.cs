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
public class UserController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    
    public UserController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    // get all users
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserDTO>))]
    public async Task<IActionResult> Get()
    {
        var users = await _context.Users.ToListAsync();
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

    // add user
    [HttpPost("{_accountType}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] UserCreateDTO userdto, [FromRoute]string _accountType)
    {
        AccountType accountType;
        switch (_accountType)
        {
            case "Azubi":
                accountType = AccountType.Azubi;
                break;
            case "ABB":
                accountType = AccountType.ABB;
                break;
            default:
                return BadRequest("Invalid account type");
        }
        
        var user = new User()
        {
            LocalUsername = userdto.Username,
            Email = userdto.Email,
        };
        
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return Created("", _mapper.Map<UserDTO>(user));
    }
    
    // login
}