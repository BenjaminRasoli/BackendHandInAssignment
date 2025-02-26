using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class InvoiceEntity
{
    public int Id { get; set; }
    public string InvoiceNumber { get; set; } = null!;
    public decimal Amount { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsPaid { get; set; }


}
