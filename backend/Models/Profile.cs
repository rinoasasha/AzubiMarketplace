using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Runtime.InteropServices.JavaScript;
using backend.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Keyless]
public class UserProfile
{
    public User assocUser { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Location Standort { get; set; }
}

[Keyless]
public class AzubiProfile : UserProfile
{
    [Column(TypeName = "year")]
    public int TrainingStartYear { get; set; }
    public TrainingOccupation TrainingOccupation { get; set; }
    
}

[Keyless]
public class ABBProfile : UserProfile
{
    public string DepartmentAbbr { get; set; }
}