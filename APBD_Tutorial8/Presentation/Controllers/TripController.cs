using APBD_Tutorial8.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Tutorial8.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripController : ControllerBase
{
    private readonly ITripService _tripService;

    public TripController(ITripService tripService)
    {
        _tripService = tripService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrips()
    {
        var trips = await _tripService.GetTripsAsync();
        return Ok(trips);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTrip(int id)
    {
        // if( await DoesTripExist(id)){
        //  return NotFound();
        // }
        // var trip = ... GetTrip(id);
        return Ok();
    }
}