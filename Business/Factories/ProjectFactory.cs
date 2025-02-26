using Business.Models;
using Data.Entities;
using System.Diagnostics;

namespace Business.Factories;

public class ProjectFactory
{
    public static ProjectEntity? Map(ProjectForm form) => form == null ? null : new ProjectEntity
    {
        ProjectName = form.ProjectName,
        Description = form.Description,
        TimeLineId = form.TimeLineId,
        StatusId = form.StatusId,
        ClientId = form.ClientId,
        ProjectManagerId = form.ProjectManagerId,
        ProjectTypeId = form.ProjectTypeId,
    };

    public static Project? Map(ProjectEntity entity) => entity  == null ? null : new Project
    {
            Id = entity.Id,
            ProjectName = entity.ProjectName,
            Description = entity.Description,
            TimeLine = TimeLineFactory.Map(entity.TimeLine),
            Status = StatusFactory.Map(entity.Status),
            Client = ClientFactory.Map(entity.Client),
            ProjectManager = EmployeeFactory.Map(entity.ProjectManager),
            ProjectType = ProjectTypeFactory.Map(entity.ProjectType),
    };

    public static ProjectEntity? Map(ProjectUpdateForm projectUpdateForm)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(projectUpdateForm);

            var entity = new ProjectEntity
            {
                Id = projectUpdateForm.Id,
                ProjectName = projectUpdateForm.ProjectName,
                Description = projectUpdateForm.Description,
                TimeLineId = projectUpdateForm.TimeLineId,
                StatusId = projectUpdateForm.StatusId,
                ClientId = projectUpdateForm.ClientId,
                ProjectManagerId = projectUpdateForm.ProjectManagerId,
                ProjectTypeId = projectUpdateForm.ProjectTypeId
            };
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

}
