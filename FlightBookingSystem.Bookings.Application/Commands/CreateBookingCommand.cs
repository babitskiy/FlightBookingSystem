using MediatR;

namespace FlightBookingSystem.Bookings.Application.Commands
{
    public record CreateBookingCommand(Guid FlightId, string PassengerName, string SeatNumber) : IRequest<Guid>;
}