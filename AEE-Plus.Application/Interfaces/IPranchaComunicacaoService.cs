using AEE_Plus.Application.DTOs.PranchaComunicacao;

namespace AEE_Plus.Application.Interfaces;
public interface IPranchaComunicacaoService
{
    Task<PranchaComunicacaoResponseDTO?> GetPranchaByIdAsync(long id);
    Task<PranchaComunicacaoResponseDTO?> GetPranchaByUsuarioIdAsync(long usuarioId);
    Task<PranchaComunicacaoResponseDTO> CreatePranchaAsync(PranchaComunicacaoRequestDTO pranchaDTO);
    Task<bool> DeletePranchaAsync(long id);

    /// <summary>
    /// Adiciona um novo card a uma prancha existente.
    /// </summary>
    /// <param name="pranchaId">O ID da prancha a ser modificada.</param>
    /// <param name="cardDTO">O novo card a ser adicionado.</param>
    /// <returns>Retorna true se o card foi adicionado com sucesso.</returns>
    Task<CardDTO?> AddCardAsync(long pranchaId, CardCreateDTO newCardDto);

    /// <summary>
    /// Atualiza um card existente em uma prancha.
    /// </summary>
    /// <param name="pranchaId">O ID da prancha.</param>
    /// <param name="cardName">O nome do card a ser atualizado (usado como identificador).</param>
    /// <param name="cardDTO">Os novos dados do card (a propriedade Name no DTO será ignorada).</param>
    /// <returns>Retorna true se o card foi atualizado com sucesso.</returns>
    Task<bool> UpdateCardAsync(long pranchaId, Guid cardId, CardRequestDTO cardUpdateDTO);

    /// <summary>
    /// Remove um card de uma prancha.
    /// </summary>
    /// <param name="pranchaId">O ID da prancha.</param>
    /// <param name="cardName">O nome do card a ser removido.</param>
    /// <returns>Retorna true se o card foi removido com sucesso.</returns>
    Task<bool> DeleteCardAsync(long pranchaId, Guid cardId);

    /// <summary>
    /// Busca um card específico pelo seu ID dentro de uma prancha.
    /// </summary>
    /// <param name="pranchaId">O ID da prancha pai.</param>
    /// <param name="cardId">O ID (Guid) do card a ser buscado.</param>
    /// <returns>O DTO do card se encontrado; caso contrário, null.</returns>
    Task<CardRequestDTO?> GetCardByIdAsync(long pranchaId, Guid cardId);
}
