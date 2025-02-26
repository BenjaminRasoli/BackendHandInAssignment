namespace Data.Entities;

public class UserEntity
{
    public int Id { get; set; }

    public int UserInfoId { get; set; }
    public UserInfoEntity UserInfo { get; set; } = null!;

    public int AddressId { get; set; }
    public AddressEntity Address { get; set; } = null!;


    public int RoleId { get; set; }
    public RoleEntity Role { get; set; } = null!;

    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
