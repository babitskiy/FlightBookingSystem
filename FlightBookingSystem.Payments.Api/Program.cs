using FlightBookingSystem.BuildingBlocks.Common;
using FlightBookingSystem.BuildingBlocks.Contracts.EventBuss.Messages;
using FlightBookingSystem.Payments.Application.Consumers;
using FlightBookingSystem.Payments.Application.Handlers;
using FlightBookingSystem.Payments.Core.Repositories;
using FlightBookingSystem.Payments.Infrastructure.Repositories;
using MassTransit;
using Microsoft.Data.SqlClient;
using Npgsql;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register MediatR
var assemblies = new Assembly[]
{
    Assembly.GetExecutingAssembly(),
    typeof(RefundPaymentHandler).Assembly,
    typeof(ProcessPaymentHandler).Assembly,
};
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

// Application Services
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

// MassTransit
builder.Services.AddMassTransit(config =>
{
    // Mark this as consumer
    config.AddConsumer<FlightBookedConsumer>();

    config.UsingRabbitMq((ct, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        cfg.ReceiveEndpoint(EventBusConstant.FlightBookedQueue, c =>
        {
            c.ConfigureConsumer<FlightBookedConsumer>(ct);
        });
    });
});

// Add SQL Connection
builder.Services.AddScoped<IDbConnection>(sp =>
    new NpgsqlConnection(builder.Configuration.GetConnectionString("PostgresConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
