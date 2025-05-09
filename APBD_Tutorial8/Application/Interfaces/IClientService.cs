using APBD_Tutorial8.Infrastructure.DTOs;

namespace APBD_Tutorial8.Application.Interfaces;

public interface IClientService
{
    Task<IEnumerable<ClientsTripDto>> GetClientsTripsByIdAsync(int clientId);
    Task<int> CreateClient(ClientDto clientDto);
    Task<(bool Success, string Message)> RegisterClientToATrip(int clientId, int tripId);
    Task<(bool Success, string Message)> DeleteClientForATrip(int clientId, int tripId);
}