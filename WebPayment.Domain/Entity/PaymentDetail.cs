using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPayment.Domain.Entity;

public class PaymentDetail
{
    [Key]
    public int PaymentDetailId { get; set; }
    
    [Column(TypeName = "varchar(100)")]
    public string CardOwnerName { get; set; } = string.Empty;

    [Column(TypeName = "varchar(16)")]
    public string CardNumber { get; set; } = string.Empty;

    //MM/YY
    [Column(TypeName = "varchar(5)")]
    public string ExpirationDate { get; set; } = string.Empty;

    [Column(TypeName = "varchar(3)")]
    public string SecurityCode { get; set; } = string.Empty;
}