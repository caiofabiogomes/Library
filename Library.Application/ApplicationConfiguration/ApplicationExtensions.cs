using Library.Application.ActionConsumers;
using Library.Infra.Consumers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application.ApplicationConfiguration
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationExtensions));
            services.AddSingleton<PaymentApprovedConsumer>();
            services.AddSingleton<PaymentApprovedEventHandler>();

            return services;
        }
        public static async Task StartPaymentProcessingAsync(this IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var paymentApprovedConsumer = services.GetRequiredService<PaymentApprovedConsumer>();
                var paymentApprovedEventHandler = services.GetRequiredService<PaymentApprovedEventHandler>();

                paymentApprovedConsumer.PaymentApproved += async (sender, e) =>
                {
                    await paymentApprovedEventHandler.HandleAsync(e);
                };

                await paymentApprovedConsumer.StartAsync(CancellationToken.None);
            }
        }

    }
}
