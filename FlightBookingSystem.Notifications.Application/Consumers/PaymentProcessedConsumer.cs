﻿using FlightBookingSystem.BuildingBlocks.Contracts.EventBuss.Messages;
using FlightBookingSystem.Notifications.Application.Commands;
using MassTransit;
using MediatR;

namespace FlightBookingSystem.Notifications.Application.Consumers
{
    public class PaymentProcessedConsumer : IConsumer<PaymentProcessedEvent>
    {
        private readonly IMediator _mediator;

        public PaymentProcessedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<PaymentProcessedEvent> context)
        {
            var paymentProcessedEvent = context.Message;
            var message = $"Payment of ${paymentProcessedEvent.Amount} for Booking ID: {paymentProcessedEvent.BookingId} was processed successfully.";
            var command = new SendNotificationCommand("someone@example.com", message, "Email");
            await _mediator.Send(command);
        }
    }
}