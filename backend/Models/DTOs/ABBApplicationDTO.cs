namespace backend.Models.DTOs;

public class ABBApplicationDTO
{
    public UserDTO Author { get; set; }
    public DateTime CreationDateTime { get; set; } = DateTime.Now;
    public string TextContent { get; set; }
    public AzubiRequestDTO RelatedRequest { get; set; }
    
}