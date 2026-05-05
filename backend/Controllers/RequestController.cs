using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Models.DTOs;
using backend.Models.Enums;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class RequestController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    
    public RequestController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    // get all requests
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        List<AzubiRequest> requests = await _context.AzubiRequests
            .Include(request => request.Responses)
            .ToListAsync();
        return Ok(_mapper.Map<List<AzubiRequestDTO>>(requests));
    }
    
    
    // get requests for user
    
    // post new application
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post([FromBody] AzubiRequestCreateDTO _request)
    {
        var userController = new UserController(_context, _mapper);
        var userResult = "keine Ahnung";
        if (userResult == null)
        {
            return NotFound();
        }
        var request = new AzubiRequest()
        {
            // Author =  userResult,
            TextContent = _request.TextContent
        };
        await _context.AzubiRequests.AddAsync(request);
        await _context.SaveChangesAsync();
        return Created("", _mapper.Map<AzubiRequestDTO>(request));
    }
}