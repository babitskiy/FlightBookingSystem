namespace FlightBookingSystem.BuildingBlocks.Contracts.EventBuss.Messages
{
    public record FlightBookedEvent(
        Guid BookingId, 
        Guid FlightId, 
        string PassengerName, 
        string SeatNumber, 
        DateTime BookingDate);
}