using FlightBookingSystem.Flights.Core.Entities;

namespace FlightBookingSystem.Flights.Core.Repositories
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetFlightsAsync();
        Task AddFlightAsync(Flight flight);
        Task RemoveFlightAsync(Guid id);
    }
}