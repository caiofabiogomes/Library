using Library.Core.IExternalServices;
using Library.Core.IRepositories;
using Library.Core.IServices;
using Library.Infra.Auth;
using Library.Infra.Consumers;
using Library.Infra.ExternalServices;
using Library.Infra.MessageBus;
using Library.Infra.Persistence;
using Library.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infra.ContextConfiguration
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("LibraryDb");

            services.AddDbContext<LibraryDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
        public static IServiceCollection AddDependenciesInfra(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IApiPaymentService, ApiPaymentService>();
            services.AddScoped<IMessageBusService, MessageBusService>();
            services.AddHostedService<PaymentApprovedConsumer>();

            return services;
        }
    }
}
