using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class PaymentRepository(DataContext context) : BaseRepository<PaymentEntity>(context), IPaymentRepository
{
}
