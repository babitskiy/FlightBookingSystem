using FlightBookingSystem.Bookings.Application.Queries;
using FlightBookingSystem.Bookings.Core.Entities;
using FlightBookingSystem.Bookings.Core.Repositories;
using MediatR;

namespace FlightBookingSystem.Bookings.Application.Handlers
{
    public class GetBookingHandler : IRequestHandler<GetBookingQuery, Booking>
    {
        private readonly IBookingRepository _bookingRepository;

        public GetBookingHandler(IBookingRepository bookingRepository) => _bookingRepository = bookingRepository;
        
        public async Task<Booking> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            return await _bookingRepository.GetBookingByIdAsync(request.Id);
        }
    }
}