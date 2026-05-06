using System.ComponentModel.DataAnnotations;
using backend.Models.Enums;
using backend.Models;

namespace backend.Models.DTOs;

public class AzubiRequestCreateDTO
{
    public string TextContent { get; set; }
}