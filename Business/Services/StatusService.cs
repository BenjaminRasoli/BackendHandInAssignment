using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class StatusService(IStatusRepository statusRepository) : IStatusService
{
    private readonly IStatusRepository _statusRepository = statusRepository;

    public async Task<IEnumerable<Status?>> GetStatusesAsync()
    {
        var entities = await _statusRepository.GetAllAsync();
        return entities.Select(StatusFactory.Map);
    }

    public async Task<Status?> GetStatusById(int id)
    {
        var entity = await _statusRepository.GetAsync(x => x.Id == id);
        return entity == null ? null : StatusFactory.Map(entity);
    }
}
