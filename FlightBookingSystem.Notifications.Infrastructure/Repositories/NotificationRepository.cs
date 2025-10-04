using Dapper;
using FlightBookingSystem.Notifications.Core.Entities;
using FlightBookingSystem.Notifications.Core.Repositories;
using System.Data;

namespace FlightBookingSystem.Notifications.Infrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly IDbConnection _dbConnection;

        public NotificationRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task LogNotificationAsync(Notification notification)
        {
            const string sql = @"
            INSERT INTO Notifications (Id, Recipient, Message, Type, SentAt)
            VALUES (@Id, @Recipient, @Message, @Type, @SentAt)";

            await _dbConnection.ExecuteAsync(sql, notification);
        }
    }
}