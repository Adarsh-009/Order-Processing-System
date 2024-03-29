using Microsoft.EntityFrameworkCore;
using OrderProcessingSystem;
using OrderProcessingSystem.Business;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<OrderDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IOrderRepository, OrderProcessing>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
