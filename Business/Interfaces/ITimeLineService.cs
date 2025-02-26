using Business.Models;

namespace Business.Interfaces
{
    public interface ITimeLineService
    {
        Task<IEnumerable<TimeLine?>> GetTimeLinesAsync();
    }
}