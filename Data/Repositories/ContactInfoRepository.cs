using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ContactInfoRepository(DataContext context) : BaseRepository<ContactInfoEntity>(context), IContactInfoRepository
{
}
