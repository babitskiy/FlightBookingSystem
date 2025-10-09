using FlightBookingSystem.Flights.Core.Entities;
using FlightBookingSystem.Flights.Core.Repositories;
using FlightBookingSystem.Flights.Infrastructure.DataSets;
using MongoDB.Driver;

namespace FlightBookingSystem.Flights.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IFlightContext _context;

        public FlightRepository(IFlightContext context)
        {
            _context = context;
        }

        public async Task AddFlightAsync(Flight flight)
        {
            await _context.Flights.InsertOneAsync(flight);
        }

        public async Task<IEnumerable<Flight>> GetFlightsAsync()
        {
            return await _context.Flights.Find(f => true).ToListAsync();
        }

        public async Task RemoveFlightAsync(Guid id)
        {
            await _context.Flights.DeleteOneAsync(f => f.Id == id);
        }
    }
}