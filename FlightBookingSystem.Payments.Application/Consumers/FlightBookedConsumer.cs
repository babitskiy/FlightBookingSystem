using FlightBookingSystem.BuildingBlocks.Contracts.EventBuss.Messages;
using FlightBookingSystem.Payments.Application.Commands;
using MassTransit;
using MediatR;

namespace FlightBookingSystem.Payments.Application.Consumers
{
    public class FlightBookedConsumer : IConsumer<FlightBookedEvent>
    {
        private readonly IMediator _mediator;

        public FlightBookedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<FlightBookedEvent> context)
        {
            var flightBookedEvent = context.Message;
            var command = new ProcessPaymentCommand(flightBookedEvent.BookingId, 200.00m);
            await _mediator.Send(command);
        }
    }
}