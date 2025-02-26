using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class AddressRepository(DataContext context) : BaseRepository<AddressEntity>(context), IAddressRepository
{
}
