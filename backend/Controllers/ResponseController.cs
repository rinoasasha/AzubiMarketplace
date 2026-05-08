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
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post([FromBody]ABBResponseCreateDTO _request)
    {
        var author = await _userManager.GetUserAsync(HttpContext.User);
        var relatedRequest = await _context.AzubiRequests
                .Include(x => x.Responses)
                .Include(x => x.Author)
                .FirstOrDefaultAsync(x => x.RequestId == _request.RelatedRequestId);
        if (author == null || relatedRequest == null)
        {
            return BadRequest();
        }

        if (!_userManager.IsInRoleAsync(author, "ABB").GetAwaiter().GetResult())
        {
            return Unauthorized();
        }

        var response = new ABBResponse()
        {
            Author =  author,
            RelatedRequest = relatedRequest,
            TextContent =  _request.TextContent
        };
        await _context.AbbResponses.AddAsync(response);
        relatedRequest.Responses.Add(response);
        await _context.SaveChangesAsync();
        
        return Created("", _mapper.Map<ABBResponseDTO>(response));
    }
}