namespace Data.Entities;

public class ClientEntity
{
    public int Id { get; set; }
    public string ClientName { get; set; } = null!;

    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
