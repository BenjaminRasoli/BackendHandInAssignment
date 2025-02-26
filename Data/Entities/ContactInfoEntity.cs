namespace Data.Entities;

public class ContactInfoEntity
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;

    public int ClientId { get; set; }
    public ClientEntity Client { get; set; } = null!;
}
