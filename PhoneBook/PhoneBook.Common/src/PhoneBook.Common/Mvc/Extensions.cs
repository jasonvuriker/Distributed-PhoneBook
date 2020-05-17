using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Common.Handlers;
using PhoneBook.Common.Repository;
using PhoneBook.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace PhoneBook.Common.Mvc
{
    public static class Extensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            var assembly = Assembly.GetEntryAssembly();

            var types = assembly.GetTypes()
                .Where(s => !s.IsAbstract && !s.IsInterface &&
                    s.GetInterfaces().Any(v =>
                        v.IsGenericType && (v.GetGenericTypeDefinition() == typeof(ICommandHandler<>) ||
                        v.GetGenericTypeDefinition() == typeof(IQueryHandler<,>))));

            foreach (var type in types)
            {
                var genericType = type.GetInterfaces().FirstOrDefault();
                services.AddScoped(genericType, type);
            }


            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }

        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
            => builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
