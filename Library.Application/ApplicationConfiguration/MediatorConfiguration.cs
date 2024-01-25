using Library.Application.Commands.User.CreateUser;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.ApplicationConfiguration
{
    public static class MediatorConfiguration
    {
        public static IServiceCollection AddMediators(this IServiceCollection services)
        {
            services.AddMediatR(typeof(MediatorConfiguration));

            return services;
        }
    }
}
