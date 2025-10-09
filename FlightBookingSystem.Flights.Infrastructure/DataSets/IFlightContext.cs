using FlightBookingSystem.Flights.Core.Entities;
using MongoDB.Driver;

namespace FlightBookingSystem.Flights.Infrastructure.DataSets
{
    public interface IFlightContext
    {
        IMongoCollection<Flight> Flights { get; }
    }
}