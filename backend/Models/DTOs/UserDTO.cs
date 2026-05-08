using backend.Models.Enums;

namespace backend.Models.DTOs;

public class UserDTO
{
    public Guid Id { get; set; }
    public string LocalUsername { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Location { get; set; }
    public string? Department { get; set; }
    public string? TrainingOccupation { get; set; }
    public int? TrainingStartYear { get; set; }
}