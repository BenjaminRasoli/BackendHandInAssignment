using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class TimeLineRepository(DataContext context) : BaseRepository<TimeLineEntity>(context), ITimeLineRepository
{
}
