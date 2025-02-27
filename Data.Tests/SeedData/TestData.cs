using Data.Entities;

namespace Data.Tests.SeedData;

public static class TestData
{

    public static readonly AddressEntity[] AddressEntities =
    [
        new AddressEntity { Id = 1, Street = "sleinper vägen 12", City = "stockholm", PostalCode = "13638", Country = "Sweden"},
        new AddressEntity { Id = 2, Street = "sleinper vägen 22", City = "stockholm", PostalCode = "15638", Country = "Sweden"},

    ];

    public static readonly ContactInfoEntity[] ContactInfoEntities =
    [
        new ContactInfoEntity { Id = 1, ClientId = 1, Email = "brjön@gmail.com", PhoneNumber = "0705321412"},
        new ContactInfoEntity { Id = 2, ClientId = 2, Email = "kevin@gmail.com", PhoneNumber = "070531212"}
    ];

    public static readonly InvoiceEntity[] InvoiceEntities =
    [
        new InvoiceEntity { Id = 1, Amount = 10, IsPaid = true, DueDate = new DateTime(2024, 3, 2), IssueDate = new DateTime(2024, 4, 2), InvoiceNumber = "1231"},
        new InvoiceEntity { Id = 2, Amount = 20, IsPaid = false, DueDate = new DateTime(2025, 3, 2), IssueDate = new DateTime(2025, 4, 2), InvoiceNumber = "1231"},
    ];

    public static readonly PaymentEntity[] PaymentEntities =
    [
        new PaymentEntity { Id = 1, Amount = 10, InvoiceId = 1, PaymentDate = new DateTime(2024, 3, 2), PaymentMethod = "card" },
        new PaymentEntity { Id = 2, Amount = 10, InvoiceId = 1, PaymentDate = new DateTime(2024, 3, 2), PaymentMethod = "card" },
    ];

    public static readonly RoleEntity[] RoleEntities =
    [
        new RoleEntity { Id = 1, Role = "admin" },
        new RoleEntity { Id = 2, Role = "superadmin" }
    ];

    public static readonly ServiceEntity[] ServiceEntities =
    [
        new ServiceEntity { Id = 1, Name = "work", PricePerHour = 10},
        new ServiceEntity { Id = 2, Name = "work", PricePerHour = 20},
    ];

    public static readonly TaskEntity[] TaskEntities =
    [
        new TaskEntity { Id = 1, UserId = 1, TaskName = "bug fixes", Status = "active", Description = "fix bugs", AssignedToId = 1, EndDate = new DateTime(2024, 3, 2) },
        new TaskEntity { Id = 2, UserId = 2, TaskName = "bug fixes", Status = "active", Description = "fix bugs", AssignedToId = 1, EndDate = new DateTime(2024, 3, 2) },
    ];

    public static readonly UserEntity[] UserEntities =
    [
    new UserEntity { Id = 1, RoleId = 1, AddressId = 1, UserInfoId = 1, Projects = ProjectEntities!  },
    new UserEntity { Id = 2, RoleId = 2, AddressId = 2, UserInfoId = 2, Projects = ProjectEntities!  },
    ];

    public static readonly UserInfoEntity[] UserInfoEntities =
    [
        new UserInfoEntity { Id = 1, Email = "karl@gmail.com", EmailAddress = "karl@gmail.com", FirstName = "karl", LastName = "bert", Password = "bytmig", SecurityKey = "bytmig"  },
        new UserInfoEntity { Id = 2, Email = "bert@gmail.com", EmailAddress = "bert@gmail.com", FirstName = "bert", LastName = "karl", Password = "bytmig", SecurityKey = "bytmig"  },
    ];


    public static readonly StatusEntity[] StatusEntities =
    [
        new StatusEntity { Id = 1, StatusName = "Ej påbörjad"},
        new StatusEntity { Id = 2, StatusName = "Pågår"},
        new StatusEntity { Id = 3, StatusName = "Avslutad"},
    ];

    public static readonly ClientEntity[] ClientEntities =
    [
        new ClientEntity { Id = 1, ClientName = "björn"},
        new ClientEntity { Id = 2, ClientName = "kvein"},
        new ClientEntity { Id = 3, ClientName = "oscar"},
    ];

    public static readonly EmployeeEntity[] EmployeeEntities =
    [
        new EmployeeEntity { Id = 1, FirstName = "peter", LastName = "andersson", Email = "peter.andersson@gmail.com"},
        new EmployeeEntity { Id = 2, FirstName = "alvin", LastName = "karl", Email = "alvin.karl@gmail.com"},
        new EmployeeEntity { Id = 3, FirstName = "bosse", LastName = "andersson", Email = "bosse.andersson@gmail.com"},
    ];

    public static readonly TimeLineEntity[] TimeLineEntities =
    [
        new TimeLineEntity { Id = 1, Days = 10},
        new TimeLineEntity { Id = 2, Days = 20},
        new TimeLineEntity { Id = 3, Days = 30},
        new TimeLineEntity { Id = 4, Days = 40},

    ];
    public static readonly ProjectEntity[] ProjectEntities = 
    [
        new ProjectEntity 
        {
            
            Id = 1,
            ProjectName = "c#",
            Description = "Kurs i C#",
            StatusId = 1,
            ClientId = 1,
            ProjectManagerId = 1,
            ProjectTypeId = 1,
            TimeLineId = 1,
        },
        new ProjectEntity
        {
            Id = 2,
            ProjectName = "react",
            Description = "Kurs i react",
            StatusId = 2,
            ClientId = 2,
            ProjectManagerId = 2,
            ProjectTypeId = 2,
            TimeLineId = 2,
        }
    ];

    public static readonly ProjectTypeEntity[] ProjectTypeEntities =
    [
        new ProjectTypeEntity { Id = 1, TypeName = "övning"},
        new ProjectTypeEntity { Id = 2, TypeName = "uppdrag"},
        new ProjectTypeEntity { Id = 3, TypeName = "handelning"},
    ];
}
