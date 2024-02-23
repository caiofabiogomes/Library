using LibraryPayment.Application.InputModels;
using LibraryPayment.Application.Interfaces;
using LibraryPayment.Infra.IServicesConsumers;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryPayment.Application.Consumers
{
    public class ProcessPaymentAction : IProcessPaymentAction
    {
        private readonly IServiceProvider _serviceProvider;
        
        public ProcessPaymentAction(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }
        
        public async Task<string> ProcessPayment(decimal value)
        {
            var paymentId = "";

            using (var scope = _serviceProvider.CreateScope())
            {
                var paymentService = scope.ServiceProvider.GetRequiredService<IProcessPaymentService>();

                var inputModel = new ProcessPaymentInputModel(value);

                paymentId = (await paymentService.ProcessPaymentCreditCard(inputModel)).Data;
            }

            return paymentId;
        }
    }
}
