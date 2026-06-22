using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebPayment.Domain.Entity;
using WebPayment.Services.Contract.DTOs;
using WebPayment.Services.Contract.IMapper;
using WebPayment.Services.DbContext;

namespace WebPayment.Services.Mapper;

public class PaymentService : IPaymentService
{
    private readonly PaymentContext _context;
    private readonly IMapper _mapper; 
    
    public PaymentService(PaymentContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
     public async Task<IEnumerable<PaymentDetailDto>> GetPaymentDetailsAsync()
    {
        var list = await _context.PaymentDetails.ToListAsync();
        return _mapper.Map<IEnumerable<PaymentDetailDto>>(list);
    }
     
    public async Task<PaymentDetailDto?> GetPaymentDetailAsync(int id)
    {
        var entity = await _context.PaymentDetails.FindAsync(id);
        return entity == null ? null : _mapper.Map<PaymentDetailDto>(entity);
    }
    
    public async Task<IEnumerable<PaymentDetailDto>?> UpdatePaymentDetailAsync(int id, PaymentDetailDto dto)
    {
        if (id != dto.PaymentDetailId) return null;

        var entity = await _context.PaymentDetails.FindAsync(id);
        if (entity == null) return null;
        
        _mapper.Map(dto, entity);
        _context.Entry(entity).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PaymentDetailExists(id)) return null;
            throw;
        }

        return await GetPaymentDetailsAsync();
    }
    
    public async Task<IEnumerable<PaymentDetailDto>> CreatePaymentDetailAsync(PaymentDetailDto dto)
    {
        var entity = _mapper.Map<PaymentDetail>(dto);
        _context.PaymentDetails.Add(entity);
        await _context.SaveChangesAsync();

        return await GetPaymentDetailsAsync();
    }
    
    public async Task<IEnumerable<PaymentDetailDto>?> DeletePaymentDetailAsync(int id)
    {
        var entity = await _context.PaymentDetails.FindAsync(id);
        if (entity == null) return null;

        _context.PaymentDetails.Remove(entity);
        await _context.SaveChangesAsync();

        return await GetPaymentDetailsAsync();
    }

    private bool PaymentDetailExists(int id)
    {
        return _context.PaymentDetails?.Any(e => e.PaymentDetailId == id) ?? false;
    }
}