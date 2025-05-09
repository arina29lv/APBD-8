using System.Data;
using APBD_Tutorial8.Domain.Interfaces;
using APBD_Tutorial8.Domain.Models;
using APBD_Tutorial8.Infrastructure.DTOs;
using APBD_Tutorial8.Infrastructure.SqlCommands;
using Dapper;

namespace APBD_Tutorial8.Infrastructure.Repository;

public class TripRepository : ITripRepository
{
    private readonly IDbConnection _connection;

    public TripRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<TripDto>> GetTripsAsync()
    {
        return await _connection.QueryAsync<TripDto>(TripSqlCommands.GetAllTrips);
    }

    public async Task<Trip> GetTripByIdAsync(int id)
    {
        return _connection.QuerySingleOrDefault<Trip>(TripSqlCommands.GetTripById, new { TripId = id });
    }
}