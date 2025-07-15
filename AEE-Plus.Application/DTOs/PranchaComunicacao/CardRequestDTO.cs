using System.Text.Json.Serialization;

namespace AEE_Plus.Application.DTOs.PranchaComunicacao;
public class CardRequestDTO
{
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("img")]
    public string Img { get; set; } = string.Empty; // Base64

    [JsonPropertyName("sound")]
    public string Sound { get; set; } = string.Empty; // Base64
}
