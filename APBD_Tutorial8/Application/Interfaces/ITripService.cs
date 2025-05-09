using APBD_Tutorial8.Infrastructure.DTOs;

namespace APBD_Tutorial8.Application.Interfaces;

public interface ITripService
{
    Task<IEnumerable<TripDto>> GetTripsAsync();
}