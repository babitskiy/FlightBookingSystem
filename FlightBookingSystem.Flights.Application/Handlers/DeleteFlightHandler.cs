using FlightBookingSystem.Flights.Application.Commands;
using FlightBookingSystem.Flights.Core.Repositories;
using MediatR;

namespace FlightBookingSystem.Flights.Application.Handlers
{
    public class DeleteFlightHandler : IRequestHandler<DeleteFlightCommand>
    {
        private readonly IFlightRepository _repository;

        public DeleteFlightHandler(IFlightRepository flightRepository)
        {
            _repository = flightRepository;
        }

        public async Task Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveFlightAsync(request.Id);
        }
    }
}