using FlightBookingSystem.BuildingBlocks.Contracts.EventBuss.Messages;
using FlightBookingSystem.Notifications.Application.Interfaces;
using FlightBookingSystem.Notifications.Core.Entities;
using MassTransit;

namespace FlightBookingSystem.Notifications.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public NotificationService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendNotificationAsync(Notification notification)
        {
            // Simulate sending a notification
            Console.WriteLine($"Notification sent to {notification.Recipient}: {notification.Message}");

            var notificationEvent = new NotificationEvent(notification.Recipient, notification.Message, notification.Type);
            await _publishEndpoint.Publish(notificationEvent);
        }
    }
}