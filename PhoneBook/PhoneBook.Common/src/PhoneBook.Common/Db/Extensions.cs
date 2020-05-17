using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Common.Db
{
    public static class Extensions
    {

        public static IServiceCollection AddSql(this IServiceCollection services)
        {
            string connectionString;
            using (var provider = services.BuildServiceProvider())
            {
                var configuration = provider.GetService<IConfiguration>();
                connectionString = configuration["sql"];
            }

            if (string.IsNullOrEmpty(connectionString))
                throw new NullReferenceException("Sql server connection string not found");

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
