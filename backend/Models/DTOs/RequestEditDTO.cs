namespace backend.Models.DTOs;

public class RequestEditDTO
{
    public Guid RequestId { get; set; }
    public string? TextContent { get; set; }
}