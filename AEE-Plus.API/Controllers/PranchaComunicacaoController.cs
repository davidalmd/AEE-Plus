using AEE_Plus.Application.DTOs.PranchaComunicacao;
using AEE_Plus.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AEE_Plus.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PranchasComunicacaoController : ControllerBase
{
    private readonly IPranchaComunicacaoService _pranchaService;

    public PranchasComunicacaoController(IPranchaComunicacaoService pranchaService)
    {
        _pranchaService = pranchaService;
    }

    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(PranchaComunicacaoResponseDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(long id)
    {
        var prancha = await _pranchaService.GetPranchaByIdAsync(id);
        return prancha == null ? NotFound() : Ok(prancha);
    }

    [HttpGet("usuario/{usuarioId:long}")]
    [ProducesResponseType(typeof(PranchaComunicacaoResponseDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByUsuarioId(long usuarioId)
    {
        var prancha = await _pranchaService.GetPranchaByUsuarioIdAsync(usuarioId);
        return prancha == null ? NotFound() : Ok(prancha);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PranchaComunicacaoResponseDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(PranchaComunicacaoRequestDTO request)
    {
        var novaPrancha = await _pranchaService.CreatePranchaAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = novaPrancha.Id }, novaPrancha);
    }

    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePrancha(long id)
    {
        var success = await _pranchaService.DeletePranchaAsync(id);
        return success ? NoContent() : NotFound();
    }

    [HttpPost("{pranchaId:long}/cards")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddCard(long pranchaId, [FromBody] CardCreateDTO newCardDTO)
    {
        var cardCriado = await _pranchaService.AddCardAsync(pranchaId, newCardDTO);

        if (cardCriado == null)
        {
            return NotFound("Prancha não encontrada.");
        }

        return CreatedAtAction(nameof(GetById), new { id = pranchaId }, cardCriado);
    }

    [HttpPut("{pranchaId:long}/cards/{cardId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCard(long pranchaId, Guid cardId, [FromBody] CardRequestDTO cardUpdateDTO)
    {
        var success = await _pranchaService.UpdateCardAsync(pranchaId, cardId, cardUpdateDTO);
        return success ? NoContent() : NotFound("Prancha ou card não encontrado.");
    }

    [HttpDelete("{pranchaId:long}/cards/{cardId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCard(long pranchaId, Guid cardId)
    {
        var success = await _pranchaService.DeleteCardAsync(pranchaId, cardId);
        return success ? NoContent() : NotFound("Prancha ou card não encontrado.");
    }

    [HttpGet("{pranchaId:long}/cards/{cardId:guid}")]
    [ProducesResponseType(typeof(CardRequestDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCardById(long pranchaId, Guid cardId)
    {
        var card = await _pranchaService.GetCardByIdAsync(pranchaId, cardId);

        if (card == null)
        {
            return NotFound("O recurso solicitado (prancha ou card) não foi encontrado.");
        }

        return Ok(card);
    }
}
