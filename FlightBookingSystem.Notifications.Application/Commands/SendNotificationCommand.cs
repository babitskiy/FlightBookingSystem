using MediatR;

namespace FlightBookingSystem.Notifications.Application.Commands
{
    public record SendNotificationCommand(string Recipient, string Message, string Type) : IRequest;
}