using System.Collections.Generic;
using System.Threading.Tasks;
using WebPayment.Services.Contract.DTOs;

namespace WebPayment.Services.Contract.IMapper;

public interface IPaymentService
{
    Task<IEnumerable<PaymentDetailDto>> GetPaymentDetailsAsync();
    Task<PaymentDetailDto?> GetPaymentDetailAsync(int id);
    Task<IEnumerable<PaymentDetailDto>?> UpdatePaymentDetailAsync(int id, PaymentDetailDto dto);
    Task<IEnumerable<PaymentDetailDto>> CreatePaymentDetailAsync(PaymentDetailDto dto);
    Task<IEnumerable<PaymentDetailDto>?> DeletePaymentDetailAsync(int id);
    
}