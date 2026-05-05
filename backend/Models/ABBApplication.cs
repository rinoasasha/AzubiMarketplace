using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class ABBApplication
{
    [Key]
    public Guid ApplicationId { get; set; } = Guid.NewGuid();
    public User Author { get; set; }
    public DateTime CreationDateTime { get; set; } = DateTime.Now;
    public string TextContent { get; set; }
    public AzubiRequest RelatedRequest { get; set; }
    
}