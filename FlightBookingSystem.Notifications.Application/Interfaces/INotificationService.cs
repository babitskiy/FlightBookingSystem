using FlightBookingSystem.Notifications.Core.Entities;

namespace FlightBookingSystem.Notifications.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendNotificationAsync(Notification notification);
    }
}