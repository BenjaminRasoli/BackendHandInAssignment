namespace Business.Models;

public class ProjectForm
{
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }

    public int TimeLineId { get; set; }
    public int StatusId { get; set; }
    public int ClientId { get; set; }
    public int ProjectManagerId { get; set; }
    public int ProjectTypeId { get; set; }
}
