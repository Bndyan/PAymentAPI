using System.Threading.Tasks;
using WebPayment.Services.Contract.DTOs;
using WebPayment.Services.Contract.IMapper;
using WebPayment.Services.DbContext;

namespace WebPayment.Services.Mapper;

public class IPaymentService : Contract.IMapper.IPaymentService
{
    private readonly PaymentContext _context;
    private readonly Contract.IMapper.IPaymentService _service;
    
    public IPaymentService(PaymentContext context, Contract.IMapper.IPaymentService service)
    {
        _context = context;
        _service = service;
    }
    
    public async Task<PaymentDetailDto> GetPaymentDetailAsync(int id)
    {
     
        var paymentDetail = await _context.PaymentDetails.FindAsync(id);
        if (paymentDetail == null) return null!;
        
        return _service.Map<PaymentDetailDto>(paymentDetail);
    }
}