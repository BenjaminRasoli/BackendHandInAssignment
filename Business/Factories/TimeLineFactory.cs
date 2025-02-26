using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class TimeLineFactory
{
    public static TimeLine? Map(TimeLineEntity entity) => entity == null ? null : new TimeLine
    {
        Id = entity.Id,
        Days = entity.Days,
    };
}
