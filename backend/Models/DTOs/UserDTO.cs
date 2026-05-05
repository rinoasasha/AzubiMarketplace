using backend.Models.Enums;

namespace backend.Models.DTOs;

public class UserDTO
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public AccountType AccountType { get; set; }
    // public Guid ProfileId { get; set; }
}