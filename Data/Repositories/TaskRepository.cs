using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class TaskRepository(DataContext context) : BaseRepository<TaskEntity>(context), ITaskRepository
{
}
