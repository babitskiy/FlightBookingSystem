using FlightBookingSystem.Flights.Core.Entities;
using MediatR;

namespace FlightBookingSystem.Flights.Application.Queries
{
    public record GetAllFlightsQuery : IRequest<IEnumerable<Flight>>;
}