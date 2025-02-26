using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{

    public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        try
        {
            var entites =  await _context.Projects
                .Include(x => x.Client)
                .Include(x => x.ProjectManager)
                .Include(x => x.Client)
                .Include(x => x.Status)
                .Include(x => x.TimeLine)
                .Include(x => x.ProjectType)
                .ToListAsync();
            return entites;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }
    }

    public override async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Projects
                .Include(x => x.Client)
                .Include(x => x.ProjectManager)
                .Include(x => x.Client)
                .Include(x => x.Status)
                .Include(x => x.TimeLine)
                .Include(x => x.ProjectType)
                .FirstOrDefaultAsync(expression);
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }
}
