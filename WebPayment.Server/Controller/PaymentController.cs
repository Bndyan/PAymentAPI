using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebPayment.Services.Contract.DTOs;
using WebPayment.Services.Contract.IMapper;
using WebPayment.Services.DbContext;

namespace WebPayment.Server.Controller;

[Route("api/[controller]")]
[ApiController]
public class PaymentController: ControllerBase
{
    private readonly PaymentContext _context;
    private readonly IPaymentService _paymentService;
    
    public PaymentController(PaymentContext context, IPaymentService paymentService)
    {
        _context = context;
        _paymentService = paymentService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaymentDetailDto>>> GetPaymentDetails()
    {
        var list = await _paymentService.GetPaymentDetailsAsync();
        return Ok(list);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PaymentDetailDto>> GetPaymentDetail(int id)
    {
        var dto = await _paymentService.GetPaymentDetailAsync(id);
        if (dto == null) return NotFound();

        return Ok(dto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<IEnumerable<PaymentDetailDto>>> PutPaymentDetail(int id, PaymentDetailDto dto)
    {
        var result = await _paymentService.UpdatePaymentDetailAsync(id, dto);
        if (result == null) return BadRequest();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<PaymentDetailDto>>> PostPaymentDetail(PaymentDetailDto dto)
    {
        var result = await _paymentService.CreatePaymentDetailAsync(dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<IEnumerable<PaymentDetailDto>>> DeletePaymentDetail(int id)
    {
        var result = await _paymentService.DeletePaymentDetailAsync(id);
        if (result == null) return NotFound();

        return Ok(result);
    }
}