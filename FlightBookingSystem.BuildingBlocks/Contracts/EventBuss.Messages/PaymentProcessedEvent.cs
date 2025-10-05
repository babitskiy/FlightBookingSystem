namespace FlightBookingSystem.BuildingBlocks.Contracts.EventBuss.Messages
{
    public record PaymentProcessedEvent(Guid PaymentId, Guid BookingId, decimal Amount, DateTime PaymentDate);
}