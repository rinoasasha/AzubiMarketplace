using System.ComponentModel.DataAnnotations;
using backend.Models.Enums;

namespace backend.Models.DTOs;

public class RegisterDTOAzubi
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string Standort { get; set; }
    public int TrainingStartYear { get; set; }
    public string TrainingOccupationAbbr { get; set; }
}

public class RegisterDTOABB
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string Standort { get; set; }
    public string DepartmentAbbr { get; set; }
}