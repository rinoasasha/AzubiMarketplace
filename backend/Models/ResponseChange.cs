using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class ResponseChange
{
    [Key]
    public Guid ChangeId { get; set; } = Guid.NewGuid();
    public Guid SessionId { get; set; }
    public ABBResponse ChangedResponse { get; set; }
    public User InitiatingUser { get; set; }
    public DateTime ChangedAt { get; set; } = DateTime.Now;
    public string PropertyName { get; set; }
    public string? OldValue { get; set; }
    public string NewValue { get; set; }
}