using APBD_Tutorial8.Application.Interfaces;
using APBD_Tutorial8.Domain.Interfaces;
using APBD_Tutorial8.Infrastructure.DTOs;

namespace APBD_Tutorial8.Application.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly ITripRepository _tripRepository;

    public ClientService(IClientRepository clientRepository, ITripRepository tripRepository)
    {
        _clientRepository = clientRepository;
        _tripRepository = tripRepository;
    }

    public async Task<IEnumerable<ClientsTripDto>> GetClientsTripsByIdAsync(int clientId)
    {
        return  await _clientRepository.GetClientsTripsByIdAsync(clientId);
    }

    public async Task<int> CreateClient(ClientDto clientDto)
    {
        return await _clientRepository.CreateClient(clientDto);
    }

    public async Task<(bool Success, string Message)> RegisterClientToATrip(int clientId, int tripId)
    {
        try
        {
            var client = await _clientRepository.GetClientByIdAsync(clientId);
            if (client == null)
                return (false, "Client not found");

            var trip = await _tripRepository.GetTripByIdAsync(tripId);
            if (trip == null)
                return (false, "Trip not found");

            var clientTrip = new RegisterClientToTripDto
            {
                IdClient = clientId,
                IdTrip = tripId,
                RegisteredAt = int.Parse(DateTime.Now.ToString("yyyyMMdd"))
            };

            await _clientRepository.RegisterClientToTrip(clientTrip);
            return (true, "Client registered successfully");
        }
        catch (Exception ex)
        {
            return (false, "Error occured");
        }
    }

    public async Task<(bool Success, string Message)> DeleteClientForATrip(int clientId, int tripId)
    {
        try
        {
            var clientAndTrip = await _clientRepository.GetClientAndTrip(clientId, tripId);
            if (clientAndTrip == null)
                return (false, "Client and Trip not found");
            

            await _clientRepository.DeleteClientForATrip(clientId, tripId);
            return (true, "Client and Trip deleted successfully");
        }
        catch (Exception ex)
        {
            return (false, "Error occured");
        }
    }
}