namespace AEE_Plus.Application.DTOs.PranchaComunicacao;
public class PranchaComunicacaoResponseDTO
{
    public long Id { get; set; }
    public List<CardDTO> Cards { get; set; } = new();
    public DateTime DataUltimaEdicao { get; set; }
    public long IdUsuario { get; set; }
}
