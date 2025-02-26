using Data.Entities;
using Microsoft.EntityFrameworkCore;
using static Data.Entities.ProjectEntity;

namespace Data.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected DataContext()
    {
    }

    public DbSet<AddressEntity> Addreses { get; set; }
    public DbSet<ClientEntity> Clients { get; set; }
    public DbSet<ContactInfoEntity> ContactInfos { get; set; }
    public DbSet<EmployeeEntity> Employees { get; set; }
    public DbSet<InvoiceEntity> Invoices { get; set; }
    public DbSet<PaymentEntity> Payments { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<ProjectTypeEntity> ProjectTypes { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<ServiceEntity> Services { get; set; }
    public DbSet<StatusEntity> Statuses { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<TimeLineEntity> TimeLines { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserInfoEntity> UserInfos { get; set; }


}
