using Dapper;
using FlightBookingSystem.Flights.Core.Entities;
using FlightBookingSystem.Flights.Core.Repositories;
using System.Data;

namespace FlightBookingSystem.Flights.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IDbConnection _dbConnection;

        public FlightRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task AddFlightAsync(Flight flight)
        {
            const string sql = @"
            INSERT INTO Flights (Id, FlightNumber, Origin, Destination, DepartureTime, ArrivalTime)
            VALUES (@Id, @FlightNumber, @Origin, @Destination, @DepartureTime, @ArrivalTime)";

            await _dbConnection.ExecuteAsync(sql, flight);
        }

        public async Task<IEnumerable<Flight>> GetFlightsAsync()
        {
            const string sql = "SELECT * FROM Flights";
            return await _dbConnection.QueryAsync<Flight>(sql);
        }

        public async Task RemoveFlightAsync(Guid id)
        {
            const string sql = "DELETE * FROM Flight WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}