﻿using Dapper;
using FlightBookingSystem.Payments.Core.Entities;
using FlightBookingSystem.Payments.Core.Repositories;
using System.Data;

namespace FlightBookingSystem.Payments.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDbConnection _dbConnection;

        public PaymentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task ProcessPaymentAsync(Payment payment)
        {
            const string sql = @"
            INSERT INTO Payments (Id, BookingId, Amount, PaymentDate)
            VALUES (@Id, @BookingId, @Amount, @PaymentDate)";

            await _dbConnection.ExecuteAsync(sql, payment);
        }

        public async Task RefundPaymentAsync(Guid id)
        {
            const string sql = "DELETE * FROM Payments WHERE Id = @Id";

            await _dbConnection.ExecuteAsync(sql, id);
        }
    }
}