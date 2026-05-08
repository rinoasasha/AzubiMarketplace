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
[Route("api/v1/[controller]")]
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
    [HttpGet("getall")]
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
    
    // edit own user profile
    [HttpPatch("edit/self")]
    public async Task<IActionResult> EditSelf([FromBody] UserEditDTO edits)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null)
        {
            return BadRequest();
        }

        var changes = new List<UserChange>();
        var sessionId = Guid.NewGuid();
        foreach (var property in edits.GetType().GetProperties())
        {
            Console.WriteLine(property);
            var valueOld = user.GetType().GetProperty(property.Name).GetValue(user);
            var valueNew = edits.GetType().GetProperty(property.Name).GetValue(edits);
            if (valueOld != valueNew && valueNew != null)
            {
                var change = new UserChange()
                {
                    SessionId =  sessionId,
                    ChangedUser =  user,
                    InitiatingUser = user,
                    PropertyName = property.Name,
                    OldValue = valueOld.ToString(),
                    NewValue = valueNew.ToString()
                };
                user.GetType().GetProperty(property.Name).SetValue(user, valueNew);
                changes.Add(change);
                _context.UserChanges.Add(change);
            }
        }
        await _userManager.UpdateAsync(user);
        await _context.SaveChangesAsync();
        return Ok(changes);
    }
    
    //edit user profile as admin
    [Authorize(Roles = "Admin")]
    [HttpPatch("edit/{userid}")]
    public async Task<IActionResult> Edit([FromBody] UserEditDTO edits, [FromRoute] string userid)
    {
        var user = await _userManager.FindByIdAsync(userid);
        var initiatingUser = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null)
        {
            return NotFound();
        }

        var changes = new List<UserChange>();
        var sessionId = Guid.NewGuid();
        foreach (var property in edits.GetType().GetProperties())
        {
            Console.WriteLine(property);
            var valueOld = user.GetType().GetProperty(property.Name).GetValue(user);
            var valueNew = edits.GetType().GetProperty(property.Name).GetValue(edits);
            if (valueOld != valueNew && valueNew != null)
            {
                var change = new UserChange()
                {
                    SessionId =  sessionId,
                    ChangedUser =  user,
                    InitiatingUser = initiatingUser,
                    PropertyName = property.Name,
                    OldValue = valueOld.ToString(),
                    NewValue = valueNew.ToString(),
                };
                user.GetType().GetProperty(property.Name).SetValue(user, valueNew);
                changes.Add(change);
                _context.UserChanges.Add(change);
            }
        }
        await _userManager.UpdateAsync(user);
        await _context.SaveChangesAsync();
        return Ok(changes);
    }
    
    // change to azubi
    [HttpPatch("azubi")]
    public async Task<IActionResult> MakeAzubi()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null)
        {
            return BadRequest();
        }

        if (await _userManager.IsInRoleAsync(user, "ABB"))
        {
            await _userManager.RemoveFromRoleAsync(user, "ABB");
        }
        await _userManager.AddToRoleAsync(user, "Azubi");
        return Ok();
    }
    
    // change to abb
    [HttpPatch("abb")]
    public async Task<IActionResult> MakeABB()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null)
        {
            return NotFound();
        }
        if (await _userManager.IsInRoleAsync(user, "Azubi"))
        {
            await _userManager.RemoveFromRoleAsync(user, "Azubi");
        }
        
        await _userManager.AddToRoleAsync(user, "ABB");
        return Ok();
    }
}