using Library.Application.ActionConsumers;
using Library.Infra.IServiceActions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application.ApplicationConfiguration
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationExtensions));
            services.AddSingleton<IPaymentApprovedAction, PaymentApprovedAction>();

            return services;
        }

    }
}
