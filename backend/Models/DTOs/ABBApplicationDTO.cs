namespace backend.Models;

public class ABBApplicationDTO
{
    public Guid ApplicationId { get; set; } = Guid.NewGuid();
    public User Author { get; set; }
    public DateTime CreationDateTime { get; set; } = DateTime.Now;
    public string TextContent { get; set; }
    public AzubiRequest RelatedRequest { get; set; }
    
}