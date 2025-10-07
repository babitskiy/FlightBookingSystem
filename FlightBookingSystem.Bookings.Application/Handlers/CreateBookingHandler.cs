using FlightBookingSystem.Bookings.Application.Commands;
using FlightBookingSystem.Bookings.Core.Entities;
using FlightBookingSystem.Bookings.Core.Repositories;
using FlightBookingSystem.BuildingBlocks.Contracts.EventBuss.Messages;
using MassTransit;
using MediatR;

namespace FlightBookingSystem.Bookings.Application.Handlers
{
    public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, Guid>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreateBookingHandler(IBookingRepository bookingRepository, IPublishEndpoint publishEndpoint)
        {
            _bookingRepository = bookingRepository;
            _publishEndpoint = publishEndpoint;
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

            // Publish FlightBookedEvent
            await _publishEndpoint.Publish(new FlightBookedEvent(
                booking.Id,
                booking.FlightId,
                booking.PassengerName,
                booking.SeatNumber,
                booking.BookingDate
                ));

            return booking.Id;
        }
    }
}