namespace FlightBookingSystem.BuildingBlocks.Contracts.EventBuss.Messages
{
    public record NotificationEvent(string Recipient, string Message, string Type);
}