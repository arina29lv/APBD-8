using System.Data;
using APBD_Tutorial8.Domain.Interfaces;
using APBD_Tutorial8.Domain.Models;
using APBD_Tutorial8.Infrastructure.DTOs;
using APBD_Tutorial8.Infrastructure.SqlCommands;
using Dapper;

namespace APBD_Tutorial8.Infrastructure.Repository;

public class CountryRepository : ICountryRepository
{
    private readonly IDbConnection _connection;

    public CountryRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<CountryDto>> GetCountriesForTripAsync(int tripId)
    {
        return await _connection.QueryAsync<CountryDto>(CountrySqlCommands.GetCountriesForTrip, new { tripId });
    }
}