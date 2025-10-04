using FlightBookingSystem.Flights.Application.Queries;
using FlightBookingSystem.Flights.Core.Entities;
using FlightBookingSystem.Flights.Core.Repositories;
using MediatR;

namespace FlightBookingSystem.Flights.Application.Handlers
{
    public class GetAllFlightsHandler : IRequestHandler<GetAllFlightsQuery, IEnumerable<Flight>>
    {
        private readonly IFlightRepository _flightRepository;

        public GetAllFlightsHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<IEnumerable<Flight>> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
        {
            return await _flightRepository.GetFlightsAsync();
        }
    }
}