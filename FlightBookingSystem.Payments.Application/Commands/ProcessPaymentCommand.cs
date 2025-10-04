using MediatR;

namespace FlightBookingSystem.Payments.Application.Commands
{
    public record ProcessPaymentCommand(Guid BookingId, decimal Amount) : IRequest<Guid>;
}