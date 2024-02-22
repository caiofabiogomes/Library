using Library.Core.DTOs;
using Library.Core.IExternalServices;
using Library.Core.IServices;
using System.Text;
using System.Text.Json;

namespace Library.Infra.ExternalServices
{
    public class ApiPaymentService : IApiPaymentService
    {
        private readonly IMessageBusService _messageBusService;
        private const string _queueName = "Payments";

        public ApiPaymentService(IMessageBusService messageBusService)
        {
            _messageBusService = messageBusService;
        }

        public void ProcessPayment(PaymentInfoDto paymentInfoDto)
        {
            string paymentInfoJson = JsonSerializer.Serialize(paymentInfoDto);

            var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);

            _messageBusService.Publish(_queueName, paymentInfoBytes);
        }
    }
}
