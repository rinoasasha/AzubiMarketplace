namespace backend.Models.DTOs;

public class ABBResponseDTO
{
    public Guid ApplicationId { get; set; }
    public UserDTO Author { get; set; }
    public DateTime CreationDateTime { get; set; } = DateTime.Now;
    public string TextContent { get; set; }
    public Guid RelatedRequestRequestId { get; set; }
}