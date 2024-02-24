using LibraryPayment.Application.Consumers;
using LibraryPayment.Application.Interfaces;
using LibraryPayment.Application.Services;
using LibraryPayment.Infra.IServicesConsumers;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryPayment.Application.ApplicationConfiguration
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddDependenciesApplication(this IServiceCollection services)
        {
            services.AddScoped<IProcessPaymentService, ProcessPaymentService>();
            services.AddSingleton<IProcessPaymentEventHander, ProcessPaymentEventHander>();

            return services;
        }
    }
}
