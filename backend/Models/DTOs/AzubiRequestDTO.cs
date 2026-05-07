using backend.Models.Enums;

namespace backend.Models.DTOs;

public class AzubiRequestDTO
{
    public UserDTO Author { get; set; }
    public DateTime CreationDateTime { get; set; }
    public string TextContent { get; set; }
    public List<ABBResponseDTO> Responses { get; set; }
}