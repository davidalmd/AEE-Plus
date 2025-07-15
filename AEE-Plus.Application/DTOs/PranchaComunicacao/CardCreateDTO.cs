using System.ComponentModel.DataAnnotations;

namespace AEE_Plus.Application.DTOs.PranchaComunicacao;
public class CardCreateDTO
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Img { get; set; } = string.Empty;
    public string Sound { get; set; } = string.Empty;
}
