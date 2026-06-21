using Microsoft.EntityFrameworkCore;
using WebPayment.Domain.Entity;

namespace WebPayment.Services.DbContext;

public class PaymentContext : Microsoft.EntityFrameworkCore.DbContext
{
    public PaymentContext(DbContextOptions<PaymentContext> options) : base(options) {}

    public DbSet<PaymentDetail> PaymentDetails => Set<PaymentDetail>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaymentContext).Assembly);
    }
}