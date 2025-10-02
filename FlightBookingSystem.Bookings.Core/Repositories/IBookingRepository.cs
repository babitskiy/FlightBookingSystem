using FlightBookingSystem.Bookings.Core.Entities;

namespace FlightBookingSystem.Bookings.Core.Repositories
{
    public interface IBookingRepository
    {
        Task<Booking> GetBookingByIdAsync(Guid bookingId);
        Task AddBookingAsync(Booking booking);
    }
}