using FlightBookingSystem.Notifications.Core.Entities;

namespace FlightBookingSystem.Notifications.Core.Repositories
{
    public interface INotificationRepository
    {
        Task LogNotificationAsync(Notification notification);
    }
}