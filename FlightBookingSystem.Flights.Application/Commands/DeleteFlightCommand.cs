using MediatR;

namespace FlightBookingSystem.Flights.Application.Commands
{
    public record DeleteFlightCommand(Guid Id) : IRequest;
}