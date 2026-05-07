using System.ComponentModel.DataAnnotations;
using backend.Models.DTOs;
using backend.Models.Enums;

namespace backend.Models;

public class AzubiRequest
{
    [Key]
    public Guid RequestId { get; set; } = Guid.NewGuid();
    public User Author { get; set; }
    public DateTime CreationDateTime { get; set; } = DateTime.Now;
    public string TextContent { get; set; }
    public List<ABBResponse> Responses { get; set; } = [];
    public bool isActive { get; set; } = true;
}