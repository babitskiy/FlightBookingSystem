using FlightBookingSystem.Notifications.Application.Interfaces;
using FlightBookingSystem.Notifications.Core.Entities;

namespace FlightBookingSystem.Notifications.Application.Services
{
    public class NotificationService : INotificationService
    {
        public async Task SendNotificationAsync(Notification notification)
        {
            // Simulate sending a notification
            Console.WriteLine($"Notification sent to {notification.Recipient}: {notification.Message}");
        }
    }
}