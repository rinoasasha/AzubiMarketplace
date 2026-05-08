using backend.Models.Enums;

namespace backend.Models.DTOs;

public class UserDTO
{
    public Guid Id { get; set; }
    public string LocalUsername { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}