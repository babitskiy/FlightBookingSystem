using FlightBookingSystem.Payments.Core.Entities;

namespace FlightBookingSystem.Payments.Core.Repositories
{
    public interface IPaymentRepository
    {
        Task ProcessPaymentAsync(Payment payment);
        Task RefundPaymentAsync(Guid id);
    }
}