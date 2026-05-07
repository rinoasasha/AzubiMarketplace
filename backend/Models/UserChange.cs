using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class UserChange
{
    [Key]
    public Guid ChangeId { get; set; } = Guid.NewGuid();
    public Guid SessionId { get; set; }
    public User ChangedUser { get; set; }
    public User InitiatingUser { get; set; }
    public DateTime ChangedAt { get; set; } = DateTime.Now;
    public string PropertyName { get; set; }
    public string? OldValue { get; set; }
    public string NewValue { get; set; }
}