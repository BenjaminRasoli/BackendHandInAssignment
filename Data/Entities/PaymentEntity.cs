using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class PaymentEntity
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; } = null!;

    public int InvoiceId { get; set; }
    public InvoiceEntity Invoice { get; set; } = null!;
}
