using System.ComponentModel.DataAnnotations;

namespace AEE_Plus.Application.DTOs.PranchaComunicacao;
public class PranchaComunicacaoRequestDTO
{
    [Required]
    public List<CardRequestDTO> Cards { get; set; } = new();

    [Required]
    public long IdUsuario { get; set; }
}
