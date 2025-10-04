using FlightBookingSystem.Payments.Application.Commands;
using FlightBookingSystem.Payments.Core.Repositories;
using MediatR;

namespace FlightBookingSystem.Payments.Application.Handlers
{
    public class RefundPaymentHandler : IRequestHandler<RefundPaymentCommand>
    {
        private readonly IPaymentRepository _repository;

        public RefundPaymentHandler(IPaymentRepository paymentRepository)
        {
            _repository = paymentRepository;
        }

        public async Task Handle(RefundPaymentCommand request, CancellationToken cancellationToken)
        {
            await _repository.RefundPaymentAsync(request.PaymentId);
        }
    }
}