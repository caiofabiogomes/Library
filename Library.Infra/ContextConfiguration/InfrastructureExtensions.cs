using Library.Core.IRepositories;
using Library.Infra.Auth;
using Library.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            services.AddScoped<IBookRepository,BookRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<ILoanRepository,LoanRepository>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
