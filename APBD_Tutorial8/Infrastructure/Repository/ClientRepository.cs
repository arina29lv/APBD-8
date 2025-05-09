using System.Data;
using APBD_Tutorial8.Domain.Interfaces;
using APBD_Tutorial8.Domain.Models;
using APBD_Tutorial8.Infrastructure.DTOs;
using APBD_Tutorial8.Infrastructure.SqlCommands;
using Dapper;

namespace APBD_Tutorial8.Infrastructure.Repository;

public class ClientRepository : IClientRepository
{
    private readonly IDbConnection _connection;

    public ClientRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<ClientsTripDto>> GetClientsTripsByIdAsync(int id)
    {
        return await _connection.QueryAsync<ClientsTripDto>(ClientSqlCommands.GetClientsTripsById, new { ClientId = id });
    }

    public async Task<int> CreateClient(ClientDto clientDto)
    {
        return await _connection.QuerySingleAsync<int>(ClientSqlCommands.CreateClient, clientDto);
    }

    public async Task<Client> GetClientByIdAsync(int id)
    {
        return await _connection.QuerySingleOrDefaultAsync<Client>(ClientSqlCommands.GetClientById, new { ClientId = id });
    }

    public async Task RegisterClientToTrip(RegisterClientToTripDto registerClientToTripDto)
    {
        await _connection.ExecuteAsync(ClientSqlCommands.RegisterClientToTrip, registerClientToTripDto);
    }

    public async Task DeleteClientForATrip(int clientId, int tripId)
    {
        await _connection.ExecuteAsync(ClientSqlCommands.DeleteClientForATrip, new { IdClient = clientId, IdTrip = tripId });
    }

    public Task<RegisterClientToTripDto> GetClientAndTrip(int clientId, int tripId)
    {
        return _connection.QuerySingleOrDefaultAsync<RegisterClientToTripDto>(ClientSqlCommands.GetClientAndTrip, new { IdClient = clientId, IdTrip = tripId });
    }
}