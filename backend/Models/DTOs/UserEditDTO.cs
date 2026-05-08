using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using backend.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace backend.Models.DTOs;

public class UserEditDTO
{
    [MaxLength(255)]
    public string? LocalUsername { get; set; }
    [MaxLength(255)]
    public string? FirstName { get; set; }
    [MaxLength(255)]
    public string? LastName { get; set; }
    [MaxLength(255)]
    public string? Location { get; set; }
    [MaxLength(20)]
    public string? Department { get; set; }
    [MaxLength(50)]
    public string? TrainingOccupation { get; set; }
    [Column(TypeName = "year")]
    public int? TrainingStartYear { get; set; }
}