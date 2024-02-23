using LibraryPayment.Core.DTOs;
using LibraryPayment.Infra.EventsInputModels;
using LibraryPayment.Infra.IServicesConsumers;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace LibraryPayment.Infra.Consumers
{
    public class ProcessPaymentConsumer : BackgroundService
    {
        private const string _queue = "Payments";
        private const string _paymentsAprovvedQueue = "PaymentsApproved";
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IProcessPaymentAction _processPaymentAction;

        public ProcessPaymentConsumer(IProcessPaymentAction processPaymentAction)
        {
            _processPaymentAction = processPaymentAction;

            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: _queue,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            _channel.QueueDeclare(
                queue: _paymentsAprovvedQueue,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) =>
            {
                var byteArray = eventArgs.Body.ToArray();
                var paymentInfoJson = Encoding.UTF8.GetString(byteArray);

                var paymentInfo = JsonSerializer.Deserialize<PaymentInfoDTO>(paymentInfoJson);

                var paymentId = await _processPaymentAction.ProcessPayment(paymentInfo.Value);

                var paymentApproved = new PaymentApprovedIntegrationEvent(paymentInfo.LoanId,paymentInfo.FinishDateLoan,paymentId,paymentInfo.Value);
                var paymentApprovedJson = JsonSerializer.Serialize(paymentApproved);
                var paymentApprovedBytes = Encoding.UTF8.GetBytes(paymentApprovedJson);

                _channel.BasicPublish(
                    exchange: "",
                    routingKey: _paymentsAprovvedQueue,
                    basicProperties: null,
                    body: paymentApprovedBytes
                    );

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(_queue, false, consumer);

            return Task.CompletedTask;
        }

        
    }
}
