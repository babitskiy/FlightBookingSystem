using FlightBookingSystem.Notifications.Application.Commands;
using FlightBookingSystem.Notifications.Application.Interfaces;
using FlightBookingSystem.Notifications.Core.Entities;
using FlightBookingSystem.Notifications.Core.Repositories;
using MediatR;

namespace FlightBookingSystem.Notifications.Application.Handlers
{
    public class SendNotificationHandler : IRequestHandler<SendNotificationCommand>
    {
        private readonly INotificationService _notificationService;

        public SendNotificationHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = new Notification()
            {
                Id = Guid.NewGuid(),
                Recipient = request.Recipient,
                Message = request.Message,
                Type = request.Type
            };

            await _notificationService.SendNotificationAsync(notification);
        }
    }
}