namespace Data.Entities;

public class TaskEntity
{
    public int Id { get; set; }
    public string TaskName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int AssignedToId { get; set; }
    public DateTime? EndDate { get; set; }
    public string Status { get; set; } = null!;

    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;
}
