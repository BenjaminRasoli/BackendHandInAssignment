namespace Data.Entities;

public partial class ProjectEntity
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }


    public int TimeLineId { get; set; }
    public TimeLineEntity TimeLine { get; set; } = null!;

    public int StatusId { get; set; }
    public StatusEntity Status { get; set; } = null!;

    public int ClientId { get; set; }
    public ClientEntity Client { get; set; } = null!;


    public int ProjectManagerId { get; set; }
    public EmployeeEntity ProjectManager { get; set; } = null!;


    public int ProjectTypeId { get; set; }
    public ProjectTypeEntity ProjectType { get; set; } = null!;
}
