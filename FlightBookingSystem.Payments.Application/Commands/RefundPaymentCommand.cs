using MediatR;

namespace FlightBookingSystem.Payments.Application.Commands
{
    public record RefundPaymentCommand(Guid PaymentId) : IRequest;
}