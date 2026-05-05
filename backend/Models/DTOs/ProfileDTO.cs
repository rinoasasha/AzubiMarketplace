using Microsoft.EntityFrameworkCore;
using backend.Models.Enums;

namespace backend.Models.DTOs;

public class ProfileDTO
{
    public Guid assocUserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Location Standort { get; set; }
}

public class AzubiProfileDTO : ProfileDTO
{
    public int Lehrjahr { get; set; }
    public string Ausbildung { get; set; }
}

public class ABBProfileDTO : ProfileDTO
{
    public string Abteilung { get; set; }
}