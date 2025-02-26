using Business.Models;

namespace Business.Interfaces
{
    public interface IStatusService
    {
        Task<Status?> GetStatusById(int id);
        Task<IEnumerable<Status?>> GetStatusesAsync();
    }
}