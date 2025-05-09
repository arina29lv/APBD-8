using APBD_Tutorial8.Application.Interfaces;
using APBD_Tutorial8.Domain.Interfaces;
using APBD_Tutorial8.Infrastructure.DTOs;

namespace APBD_Tutorial8.Application.Services;

public class TripService : ITripService
{
    private readonly ITripRepository _tripRepository;
    private readonly ICountryRepository _countryRepository;

    public TripService(ITripRepository tripRepository, ICountryRepository countryRepository)
    {
        _tripRepository = tripRepository;
        _countryRepository = countryRepository;
    }

    public async Task<IEnumerable<TripDto>> GetTripsAsync()
    {
        var trips =  await _tripRepository.GetTripsAsync();
        foreach (var trip in trips)
        {
            trip.Countries = (List<CountryDto>)await _countryRepository.GetCountriesForTripAsync(trip.Id);
        }
        
        return trips;
    }
}