using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<IEnumerable<Client?>> GetClientsAsync()
    {
        var entities = await _clientRepository.GetAllAsync();
        return entities.Select(ClientFactory.Map);
    }
}
