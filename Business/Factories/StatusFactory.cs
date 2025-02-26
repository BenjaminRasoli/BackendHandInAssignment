using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class StatusFactory
{
    public static Status? Map(StatusEntity entity) => entity == null ? null : new Status
    {
        Id = entity.Id,
        StatusName = entity.StatusName
    };
}
