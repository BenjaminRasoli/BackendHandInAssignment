using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class TimeLineService(ITimeLineRepository timeLineRepository) : ITimeLineService
{
    private readonly ITimeLineRepository _timeLineRepository = timeLineRepository;

    public async Task<IEnumerable<TimeLine?>> GetTimeLinesAsync()
    {
        var entities = await _timeLineRepository.GetAllAsync();
        return entities.Select(TimeLineFactory.Map);
    }
}

