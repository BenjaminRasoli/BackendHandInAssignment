using Data.Entities;

namespace Business.Models;

public class Project
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }


    public TimeLine? TimeLine { get; set; }
    public Status? Status { get; set; } 
    public Client? Client { get; set; } 
    public Employee? ProjectManager { get; set; } 
    public ProjectType? ProjectType { get; set; } 
}
