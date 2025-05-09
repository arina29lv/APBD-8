using APBD_Tutorial8.Application.Interfaces;
using APBD_Tutorial8.Infrastructure.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Tutorial8.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("{id}/trips")]
    public async Task<IActionResult> GetClient(int id)
    {
        return Ok(await _clientService.GetClientsTripsByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] ClientDto dto)
    {
        return StatusCode(201, new {Id =await _clientService.CreateClient(dto)});
    }

    [HttpPut("{id}/trips/{tripId}")]
    public async Task<IActionResult> RegisterClientForATrip(int id, int tripId)
    {
        var result = await _clientService.RegisterClientToATrip(id, tripId);

        if (result.Success)
            return Ok(new { message = result.Message });

        return BadRequest(new { message = result.Message });
    }

    [HttpDelete("{id}/trips/{tripId}")]
    public async Task<IActionResult> DeleteClientForATrip(int id, int tripId)
    {
        var result = await _clientService.DeleteClientForATrip(id, tripId);
        
        if (result.Success)
            return NoContent();
        
        return BadRequest(new { message = result.Message });
    }
}