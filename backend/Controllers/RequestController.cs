using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Models.DTOs;
using backend.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RequestController : ControllerBase
{
    private readonly DataContext _context;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    
    public RequestController(DataContext context, UserManager<User> userManager, IMapper mapper)
    {
        _context = context;
        _userManager = userManager;
        _mapper = mapper;
    }
    
    // get all requests
    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        List<AzubiRequest> requests = await _context.AzubiRequests
            .Include(request => request.Responses)
            .ToListAsync();
        return Ok(_mapper.Map<List<AzubiRequestDTO>>(requests));
    }
    
    
    // get requests for user
    
    // post new request
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post([FromBody] AzubiRequestCreateDTO _request)
    {
        var author = await _userManager.GetUserAsync(HttpContext.User);
        if (author == null)
        {
            return BadRequest();
        }

        if (!_userManager.IsInRoleAsync(author, "Azubi").GetAwaiter().GetResult())
        {
            return Unauthorized();
        }
        
        var request = new AzubiRequest()
        {
            Author = author,
            TextContent = _request.TextContent
        };
        await _context.AzubiRequests.AddAsync(request);
        await _context.SaveChangesAsync();
        return Created("", _mapper.Map<AzubiRequestDTO>(request));
    }
    
    // edit request
    
    // delete request
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody]string requestId)
    {
        var request = await _context.AzubiRequests.FindAsync(requestId);
        var user = await _userManager.GetUserAsync(HttpContext.User);
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        if (request == null || user == null)
        {
            return NotFound();
        }
        if (user != request.Author && !isAdmin)
        {
            return Unauthorized();
        }
        var change = new RequestChange()
        {
            SessionId =  Guid.NewGuid(),
            InitiatingUser = user,
            ChangedRequest = request,
            PropertyName = "isActive",
            OldValue = request.isActive.ToString(),
            NewValue = false.ToString()
        };
        request.isActive = false;
        _context.AzubiRequests.Update(request);
        await _context.RequestChanges.AddAsync(change);
        await _context.SaveChangesAsync();
        return Ok();
    }
}