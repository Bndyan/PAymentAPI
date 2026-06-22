using System.Threading.Tasks;
using WebPayment.Services.Contract.DTOs;

namespace WebPayment.Services.Contract.IMapper;

public interface PaymentService
{
    Task<PaymentDetailDto> GetPaymentDetailAsync(int id);
    
}