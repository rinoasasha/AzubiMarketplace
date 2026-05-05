using System.ComponentModel.DataAnnotations;
using backend.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace backend.Models;

public class User : IdentityUser<Guid>
{
    [MaxLength(255)]
    public string LocalUsername { get; set; } = null!;
    [MaxLength(255)]
    public string FirstName { get; set; } = null!;
    [MaxLength(255)]
    public string LastName { get; set; } = null!;
}