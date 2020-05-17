using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Common.Dispatchers
{
    public static class Extensions
    {
        public static IServiceCollection AddDispatchers(this IServiceCollection services)
        {
            services.AddScoped<IDispatcher, Dispatcher>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();

            return services;
        }
    }
}
