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
[Route("api/[controller]")]
public class ResponseController : ControllerBase
{
    private readonly DataContext _context;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    
    public ResponseController(DataContext context, UserManager<User> userManager, IMapper mapper)
    {
        _context = context;
        _userManager = userManager;
        _mapper = mapper;
    }
    
    // get all responses for request
    
    // post new response
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]ABBApplicationCreateDTO _request)
    {
        var author = await _userManager.GetUserAsync(HttpContext.User);
        var relatedRequest = await _context.AzubiRequests.FirstOrDefaultAsync(x => x.RequestId == _request.RelatedRequestId);
        if (author == null || relatedRequest == null)
        {
            return BadRequest();
        }

        if (!_userManager.IsInRoleAsync(author, "ABB").GetAwaiter().GetResult())
        {
            return Unauthorized();
        }

        var response = new ABBApplication()
        {
            Author =  author,
            RelatedRequest = relatedRequest,
            TextContent =  _request.TextContent
        };
        await _context.ABBApplications.AddAsync(response);
        relatedRequest.Responses.Add(response);
        await _context.SaveChangesAsync();
        return Ok();
    }
}