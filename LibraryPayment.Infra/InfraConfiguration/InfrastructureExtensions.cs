using LibraryPayment.Core.Interfaces.Integrations;
using LibraryPayment.Infra.Consumers;
using LibraryPayment.Infra.Integration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryPayment.Infra.InfraConfiguration
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddDependenciesInfra(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddSingleton<IPaymentStripeIntegration, PaymentStripeIntegration>(_ => new PaymentStripeIntegration(configuration.GetSection("Stripe:SecretKey").Value));
            
            services.AddHostedService<ProcessPaymentConsumer>();

            return services;
        }
    }
}
