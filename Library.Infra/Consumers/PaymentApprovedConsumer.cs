using Library.Core.IntegrationEvents;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Library.Infra.Consumers
{
    public class PaymentApprovedConsumer : BackgroundService
    {
        private const string _paymentApprovedQueue = "PaymentsApproved";
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public PaymentApprovedConsumer()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: _paymentApprovedQueue,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, eventArgs) =>
            {
                var paymentApprovedBytes = eventArgs.Body.ToArray();
                var paymentApprovedJson = Encoding.UTF8.GetString(paymentApprovedBytes);

                var paymentApprovedIntegrationEvent = JsonSerializer.Deserialize<PaymentApprovedIntegrationEvent>(paymentApprovedJson);

                var paymentApprovedEvent = new PaymentApprovedIntegrationEvent(paymentApprovedIntegrationEvent.LoanId,
                                                                               paymentApprovedIntegrationEvent.FinishDateLoan,
                                                                               paymentApprovedIntegrationEvent.PaymentId,
                                                                               paymentApprovedIntegrationEvent.TotalValuePaid);


                OnPaymentApproved(paymentApprovedEvent);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(_paymentApprovedQueue, false, consumer);

            return Task.CompletedTask;
        }

        public event EventHandler<PaymentApprovedIntegrationEvent> PaymentApproved;

        protected virtual void OnPaymentApproved(PaymentApprovedIntegrationEvent e)
        {
            PaymentApproved?.Invoke(this, e);
        }
    }
}
