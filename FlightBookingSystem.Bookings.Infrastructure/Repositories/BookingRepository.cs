using Dapper;
using FlightBookingSystem.Bookings.Core.Entities;
using FlightBookingSystem.Bookings.Core.Repositories;
using System.Data;

namespace FlightBookingSystem.Bookings.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IDbConnection _dbConnection;

        public BookingRepository(IDbConnection dbconnection)
        {
            _dbConnection = dbconnection;
        }

        public async Task AddBookingAsync(Booking booking)
        {
            const string sql = @"
            INSERT INTO Bookings (Id, FlightId, PassengerName, SeatNumber, BookingDate)
            VALUES (@Id, @FlightId, @PassengerName, @SeatNumber, @BookingDate)";

            await _dbConnection.ExecuteAsync(sql, booking);
        }

        public async Task<Booking> GetBookingByIdAsync(Guid id)
        {
            const string sql = "SELECT * FROM Booking WHERE Id = @Id";

            return await _dbConnection.QuerySingleOrDefaultAsync<Booking>(sql, new {Id = id});
        }
    }
}