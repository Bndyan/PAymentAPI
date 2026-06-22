using Microsoft.Extensions.DependencyInjection;
using WebPayment.Services.Contract.IMapper;
using WebPayment.Services.Mapper;

namespace WebPayment.Services.ServiceRegistration;

public static class ServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPaymentService, PaymentService>();
        
        return services;
    }
}