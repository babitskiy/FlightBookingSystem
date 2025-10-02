namespace FlightBookingSystem.Payments.Core.Repositories
{
    public interface IPaymentRepository
    {
        Task ProcessPaymentAsync(Guid id);
        Task RefundPaymentAsync(Guid id);
    }
}