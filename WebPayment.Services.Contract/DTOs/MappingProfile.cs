using AutoMapper;
using WebPayment.Domain.Entity;

namespace WebPayment.Services.Contract.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PaymentDetail, PaymentDetailDto>();
        CreateMap<PaymentDetailDto, PaymentDetail>();
    }
    
}