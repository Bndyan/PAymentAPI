using Microsoft.Extensions.DependencyInjection;
using WebPayment.Services.Contract.IMapper;

namespace WebPayment.Services.Contract.ServiceRegistration;

public static class ServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPaymentService, PaymentService>();
        
        return services;
    }
}