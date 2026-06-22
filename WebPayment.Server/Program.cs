using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using WebPayment.Services.Contract.DTOs;
using WebPayment.Services.DbContext;
using WebPayment.Services.ServiceRegistration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Host.UseSerilog((context, configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddDbContext<PaymentContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddServices();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<PaymentContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment Web API");
        }
    );
}


app.UseAuthorization();

app.MapControllers();

app.Run();

