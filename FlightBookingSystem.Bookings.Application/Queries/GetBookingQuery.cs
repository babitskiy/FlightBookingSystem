using FlightBookingSystem.Bookings.Core.Entities;
using MediatR;

namespace FlightBookingSystem.Bookings.Application.Queries
{
    public record GetBookingQuery(Guid Id) : IRequest<Booking>;
}