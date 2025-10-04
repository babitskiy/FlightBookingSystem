using FlightBookingSystem.Bookings.Application.Commands;
using FlightBookingSystem.Bookings.Core.Entities;
using FlightBookingSystem.Bookings.Core.Repositories;
using MediatR;

namespace FlightBookingSystem.Bookings.Application.Handlers
{
    public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, Guid>
    {
        private readonly IBookingRepository _bookingRepository;

        public CreateBookingHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = new Booking()
            {
                Id = Guid.NewGuid(),
                FlightId = request.FlightId,
                PassengerName = request.PassengerName,
                SeatNumber = request.SeatNumber,
                BookingDate = DateTime.UtcNow
            };

            await _bookingRepository.AddBookingAsync(booking);

            return booking.Id;
        }
    }
}