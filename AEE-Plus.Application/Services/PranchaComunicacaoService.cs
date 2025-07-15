using AEE_Plus.Application.DTOs.PranchaComunicacao;
using AEE_Plus.Application.Interfaces;
using AEE_Plus.Domain.Entities.PranchaComunicacao;
using AEE_Plus.Domain.Interfaces;
using System.Text.Json;

namespace AEE_Plus.Application.Services;

public class PranchaComunicacaoService : IPranchaComunicacaoService
{
    private readonly IPranchaComunicacaoRepository _repository;
    // DTO auxiliar para o formato de armazenamento
    private class CardStorageDTO { public string Img { get; set; } = string.Empty; public string Sound { get; set; } = string.Empty; }

    public PranchaComunicacaoService(IPranchaComunicacaoRepository repository)
    {
        _repository = repository;
    }

    public async Task<PranchaComunicacaoResponseDTO> CreatePranchaAsync(PranchaComunicacaoRequestDTO pranchaDTO)
    {
        var cardsParaArmazenar = pranchaDTO.Cards.Select(cardInfo => new CardDTO
        {
            Id = Guid.NewGuid(),
            Name = cardInfo.Name,
            Img = cardInfo.Img,
            Sound = cardInfo.Sound
        }).ToList();

        var pranchaEntity = new PranchaComunicacaoEntity(
            id: 0,
            cards: JsonSerializer.Serialize(cardsParaArmazenar), // Serializa o dicionário
            dataUltimaEdicao: DateTime.UtcNow,
            idUsuario: pranchaDTO.IdUsuario
        );

        await _repository.AddAsync(pranchaEntity);
        await _repository.SaveChangesAsync();

        return MapEntityToResponseDTO(pranchaEntity);
    }

    public async Task<PranchaComunicacaoResponseDTO?> GetPranchaByIdAsync(long id)
    {
        var prancha = await _repository.GetByIdAsync(id);
        return prancha == null ? null : MapEntityToResponseDTO(prancha);
    }

    public async Task<PranchaComunicacaoResponseDTO?> GetPranchaByUsuarioIdAsync(long usuarioId)
    {
        var prancha = await _repository.GetByUsuarioIdAsync(usuarioId);
        return prancha == null ? null : MapEntityToResponseDTO(prancha);
    }

    public async Task<bool> DeletePranchaAsync(long id)
    {
        var prancha = await _repository.GetByIdAsync(id);
        if (prancha == null) return false;
        _repository.Delete(prancha);
        return await _repository.SaveChangesAsync();
    }

    public async Task<CardDTO?> AddCardAsync(long pranchaId, CardCreateDTO newCardDTO)
    {
        var prancha = await _repository.GetByIdAsync(pranchaId);
        if (prancha == null) return null; // Prancha não encontrada

        var cards = string.IsNullOrEmpty(prancha.Cards)
            ? new List<CardDTO>()
            : JsonSerializer.Deserialize<List<CardDTO>>(prancha.Cards) ?? new List<CardDTO>();

        var novoCard = new CardDTO
        {
            Id = Guid.NewGuid(),
            Name = newCardDTO.Name,
            Img = newCardDTO.Img,
            Sound = newCardDTO.Sound
        };

        cards.Add(novoCard);

        prancha.Cards = JsonSerializer.Serialize(cards);
        prancha.DataUltimaEdicao = DateTime.UtcNow;

        _repository.Update(prancha);
        await _repository.SaveChangesAsync();

        return novoCard;
    }

    public async Task<bool> UpdateCardAsync(long pranchaId, Guid cardId, CardRequestDTO cardUpdateDTO)
    {
        var prancha = await _repository.GetByIdAsync(pranchaId);
        if (prancha == null) return false;

        var cards = JsonSerializer.Deserialize<List<CardDTO>>(prancha.Cards) ?? new List<CardDTO>();

        var cardToUpdate = cards.FirstOrDefault(c => c.Id == cardId);
        if (cardToUpdate == null) return false; // Card não encontrado na lista

        if (!string.IsNullOrEmpty(cardUpdateDTO.Name))
            cardToUpdate.Name = cardUpdateDTO.Name;
        if (!string.IsNullOrEmpty(cardUpdateDTO.Img))
            cardToUpdate.Img = cardUpdateDTO.Img;
        if (!string.IsNullOrEmpty(cardUpdateDTO.Sound))
            cardToUpdate.Sound = cardUpdateDTO.Sound;

        prancha.Cards = JsonSerializer.Serialize(cards);
        prancha.DataUltimaEdicao = DateTime.UtcNow;

        _repository.Update(prancha);
        return await _repository.SaveChangesAsync();
    }

    public async Task<bool> DeleteCardAsync(long pranchaId, Guid cardId)
    {
        var prancha = await _repository.GetByIdAsync(pranchaId);
        if (prancha == null) return false;

        var cards = JsonSerializer.Deserialize<List<CardDTO>>(prancha.Cards) ?? new List<CardDTO>();

        var cardToRemove = cards.FirstOrDefault(c => c.Id == cardId);
        if (cardToRemove == null) return false; // Card não encontrado

        cards.Remove(cardToRemove);

        prancha.Cards = JsonSerializer.Serialize(cards);
        prancha.DataUltimaEdicao = DateTime.UtcNow;

        _repository.Update(prancha);
        return await _repository.SaveChangesAsync();
    }

    public async Task<CardRequestDTO?> GetCardByIdAsync(long pranchaId, Guid cardId)
    {
        var prancha = await _repository.GetByIdAsync(pranchaId);
        if (prancha == null || string.IsNullOrEmpty(prancha.Cards))
        {
            return null;
        }

        var cards = JsonSerializer.Deserialize<List<CardDTO>>(prancha.Cards) ?? new List<CardDTO>();

        var cardEncontrado = cards.FirstOrDefault(c => c.Id == cardId);

        if (cardEncontrado == null)
            return null; // Card não encontrado

        return new CardRequestDTO
        {
            Name = cardEncontrado.Name,
            Img = cardEncontrado.Img,
            Sound = cardEncontrado.Sound
        };
    }

    // Método auxiliar para mapear a Entidade para o DTO de Resposta
    private PranchaComunicacaoResponseDTO MapEntityToResponseDTO(PranchaComunicacaoEntity entity)
    {
        return new PranchaComunicacaoResponseDTO
        {
            Id = entity.Id,
            Cards = string.IsNullOrEmpty(entity.Cards)
                ? new List<CardDTO>()
                : JsonSerializer.Deserialize<List<CardDTO>>(entity.Cards) ?? new List<CardDTO>(),
            DataUltimaEdicao = entity.DataUltimaEdicao,
            IdUsuario = entity.IdUsuario
        };
    }
}
